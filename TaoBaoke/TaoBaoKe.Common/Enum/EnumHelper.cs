using System;
using System.Collections.Generic;//键值对
using System.ComponentModel;
using System.Reflection;//反射
using TaoBaoKe.Entity.Enum;

namespace TaoBaoKe.Common.Enum
{
    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public class EnumHelper
    {
        #region 列举所有枚举值和描述

        /// <summary>
        /// 列举所有枚举值和描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> GetDescriptionDictionary<T>() where T : struct
        {
            Type type = typeof(T);
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (int item in System.Enum.GetValues(type))
            {
                string description = string.Empty;
                try
                {
                    FieldInfo fieldInfo = type.GetField(System.Enum.GetName(type, item));
                    if (fieldInfo == null)
                    {
                        continue;
                    }
                    DescriptionAttribute da = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
                    if (da == null)
                    {
                        continue;
                    }
                    description = da.Description;
                }
                catch { }
                dictionary.Add(item, description);
            }
            return dictionary;
        }

        #endregion
        #region 列举所有枚举值和索引

        /// <summary>
        /// 列举所有枚举值和索引
        /// </summary>
        /// <param name="typeParam"></param>
        /// <returns></returns>
        public static Dictionary<int, string> EnumToFieldDictionary(Type typeParam)
        {
            //Type typeParam = typeof(obj);
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (int i in System.Enum.GetValues(typeParam))
            {
                string name = System.Enum.GetName(typeParam, i);
                dictionary.Add(i, name);
            }
            return dictionary;
        } 
        #endregion

        #region 获取指定枚举值的描述

        /// <summary>
        /// 获取指定枚举值的描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetDescription<T>(T request) where T : struct
        {
            try
            {
                Type type = request.GetType();
                FieldInfo fieldInfo = type.GetField(request.ToString());

                if (fieldInfo == null) { return string.Empty; }

                DescriptionAttribute da = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

                if (da != null)
                {
                    return da.Description;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion

        #region 将枚举转成List
        public static List<EnumberEntity> EnumToList<T>()
        {
            List<EnumberEntity> list = new List<EnumberEntity>();

            foreach (var e in System.Enum.GetValues(typeof(T)))
            {
                EnumberEntity m = new EnumberEntity();
                object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objArr != null && objArr.Length > 0)
                {
                    DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                    m.Desction = da.Description;
                }
                m.EnumValue = Convert.ToInt32(e);
                m.EnumName = e.ToString();
                list.Add(m);
            }
            return list;
        }
        #endregion
    }
}
