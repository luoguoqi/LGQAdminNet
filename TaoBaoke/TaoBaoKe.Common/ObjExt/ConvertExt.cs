﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
namespace TaoBaoKe.Common.ObjExt
{
  /// <summary>字条串转换扩展@乐章</summary>
        public static class ConvertExt
        {
            //MD5加密运算字符串
            public static readonly string MD5SECRET = "L82V6ZVD6JMD5";

            /// <summary>数据库空时间 </summary>
            public static readonly DateTime NullSqlDateTime = ((DateTime)System.Data.SqlTypes.SqlDateTime.Null);
            public static bool ToBoolean(this string source)
            {
                bool reValue;
                bool.TryParse(source, out reValue);
                return reValue;
            }
            /// <summary>转化为Byte型</summary>
            public static Byte ToByte(this string source)
            {
                Byte reValue;
                Byte.TryParse(source, out reValue);
                return reValue;
            }
            /// <summary> 转化为Short型</summary>
            public static short ToShort(this string source)
            {
                short reValue;
                short.TryParse(source, out reValue);
                return reValue;
            }
            /// <summary>转化为Short型</summary>
            public static short ToInt16(this string source)
            {
                short reValue;
                short.TryParse(source, out reValue);
                return reValue;
            }

            /// <summary>转化为int32型</summary>
            public static int ToInt32(this string source)
            {
                int reValue;
                Int32.TryParse(source, out reValue);
                return reValue;
            }
            /// <summary>转化为int32型</summary>
            /// <param name="defaultValue">默认值</param>
            /// <returns></returns>
            public static int ToInt32(this string source, int defaultValue = 0)
            {
                int reValue;
                return Int32.TryParse(source, out reValue) ? reValue : defaultValue;
            }
            /// <summary>转化为int64型</summary>
            public static long ToInt64(this string source)
            {
                long reValue;
                Int64.TryParse(source, out reValue);
                return reValue;
            }
            /// <summary>转化为Float型</summary>
            public static float ToFloat(this string source)
            {
                float reValue;
                float.TryParse(source, out reValue);
                return reValue;
            }
            /// <summary>转化为Double型</summary>
            public static Double ToDouble(this string source)
            {
                Double reValue;
                Double.TryParse(source, out reValue);
                return reValue;
            }
            /// <summary>转化为decimal型</summary>
            public static decimal ToDecimal(this string source)
            {
                decimal reValue;
                decimal.TryParse(source, out reValue);
                return reValue;
            }
            /// <summary>转化为日期为空里返回NullSqlDateTime,byark</summary>
            public static DateTime ToDateTime(this string source)
            {
                DateTime reValue;
                return DateTime.TryParse(source, out reValue) ? reValue : new DateTime(1900, 01, 01);
            }
            /// <summary>转化为日期为空里返回NullSqlDateTime,byark</summary>
            public static DateTime ToDateTimeByNum(this string source)
            {
                DateTime reValue = NullSqlDateTime;
                if (source.Length == 14)
                {
                    if (!DateTime.TryParse(source.Substring(0, 4) + "-" + source.Substring(4, 2) + "-" + source.Substring(6, 2) + " "
                        + source.Substring(8, 2) + ":" + source.Substring(10, 2) + ":" + source.Substring(12, 2), out reValue))
                        reValue = NullSqlDateTime;
                }
                return reValue;
            }
            /// <summary>转化为数字类型的日期</summary>
            public static decimal ToDateTimeDecimal(this string source)
            {
                DateTime reValue;
                return DateTime.TryParse(source, out reValue) ? reValue.ToString("yyyyMMddHHmmss").ToDecimal() : 0;
            }
            /// <summary>将时间转换成数字</summary>
            public static decimal ToDateTimeDecimal(this DateTime source)
            {
                return source.ToString("yyyyMMddHHmmss").ToDecimal();
            }
            /// <summary>将时间转换成字串</summary>
            public static string ToISO8601DateString(this DateTime dateTime)
            {
                return dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            }

            #region 将Dunull字段赋值

            /// <summary> 字符串是否为DateTime类型</summary>
            /// <param name="dateString"></param>
            /// <returns></returns>
            public static bool IsDateTime(object dateObj)
            {
                if (dateObj == null)
                    return false;
                return IsDateTime(dateObj.ToString());
            }

            /// <summary> 将Dunull字段赋值转为时间</summary>
            /// <param name="time"></param>
            /// <returns></returns>
            public static DateTime ToTime(object time)
            {
                DateTime dt = DateTime.Parse("1900-1-1");
                if (time == null || DBNull.Value == time)
                {
                    return dt;
                }
                if (IsDateTime(time))
                {
                    dt = DateTime.Parse(time.ToString());
                }
                return dt;
            }
            #endregion

            /// <summary> 将IP转换为long型</summary>
            public static long ToIPLong(this string ip)
            {
                byte[] bytes = IPAddress.Parse(ip).GetAddressBytes();
                return (long)bytes[3] + (((uint)bytes[2]) << 8) + (((uint)bytes[1]) << 16) + (((uint)bytes[0]) << 24);
            }
            /// <summary> 将Int64转换成IPAddress</summary>
            public static IPAddress ToIPAddress(this Int64 source)
            {
                Byte[] b = new Byte[4];
                for (int i = 0; i < 4; i++)
                    b[3 - i] = (Byte)(source >> 8 * i & 255);
                return (new IPAddress(b));
            }
            /// <summary>将已经为 HTTP 传输进行过 HTML 编码的字符串转换为已解码的字符串</summary>
            public static string HtmlDecode(this string s)
            {
                return HttpUtility.HtmlDecode(s);
            }
            /// <summary>将字符串转换为 HTML 编码的字符串</summary>
            public static string HtmlEncode(this string s)
            {
                return HttpUtility.HtmlEncode(s);
            }
            /// <summary>对 URL 字符串进行编码</summary>
            public static string UrlEncode(this string s)
            {
                return HttpUtility.UrlEncode(s);
            }
            /// <summary>将已经为在 URL 中传输而编码的字符串转换为解码的字符串</summary>
            public static string UrlDecode(this string s)
            {
                return HttpUtility.UrlDecode(s);
            }
            /// <summary>转义</summary>
            public static string RegexDecode(this string s)
            {
                return Regex.Unescape(s);
            }
            /// <summary>通过将最少量的一组字符（\、*、+、?、|、{、[、(、)、^、$、.、# 和空白）替换为其转义码
            /// ，将这些字符转义。此操作指示正则表达式引擎以字面意义而非按元字符解释这些字符</summary>
            public static string RegexEncode(this string s)
            {
                return Regex.Escape(s);
            }
            public static T ToEnum<T>(this string instance, T defaultValue) where T : struct, IComparable, IFormattable
            {
                T convertedValue = defaultValue;
                if (!string.IsNullOrWhiteSpace(instance) && !System.Enum.TryParse(instance.Trim(), true, out convertedValue))
                    convertedValue = defaultValue;
                return convertedValue;
            }
            /// <summary> 将取输入的字符串的md5值</summary>
            /// <param name="inputstr">输入的字符串</param>
            /// <param name="otherstr">参与运算的字符</param>
            /// <returns></returns>
            public static string ToMD5(this string s, string otherstr)
            {
                string value = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(s + otherstr, "md5");
                if (!string.IsNullOrEmpty(value))
                    return value;
                else
                    return null;
            }
            /// <summary> 截取指定字符串长度（自动区分中英文）</summary>
            /// <param name="stringToSub">待截取的字符串</param>
            /// <param name="length">需要截取的长度</param>
            /// <param name="endstring">如果截断则显示的字符（例如：。。。）</param>
            /// <returns></returns>
            public static string GetSubString(string stringToSub, int length, string endstring)
            {
                if (!string.IsNullOrEmpty(stringToSub))
                {
                    Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
                    Regex regexq = new Regex("[^\x00-\xff]+", RegexOptions.Compiled);
                    char[] stringChar = stringToSub.ToCharArray();
                    StringBuilder sb = new StringBuilder();
                    int nLength = 0;
                    bool isCut = false;
                    for (int i = 0; i < stringChar.Length; i++)
                    {
                        if (regex.IsMatch((stringChar[i]).ToString()) || regexq.IsMatch((stringChar[i]).ToString()))
                        {
                            sb.Append(stringChar[i]);
                            nLength += 2;
                        }
                        else
                        {
                            sb.Append(stringChar[i]);
                            nLength = nLength + 1;
                        }

                        if (nLength > length)
                        {
                            isCut = true;
                            break;
                        }
                    }
                    if (isCut)
                        return sb.ToString() + endstring;
                    else
                        return sb.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }

            /// <summary> 截取客户端指定长度的字符串并对输入的字符串验证</summary>
            /// <param name="text">客户端输入字符串</param>
            /// <param name="maxLength">最大长度</param>
            /// <returns>清理后的字符串</returns>
            public static string ClearInputText(string text, int maxLength)
            {
                if (string.IsNullOrEmpty(text))
                    return string.Empty;
                text = text.Trim();
                if (string.IsNullOrEmpty(text))
                    return string.Empty;
                if (text.Length > maxLength)
                    text = text.Substring(0, maxLength);
                text = Regex.Replace(text, "[\\s]{2,}", " ");        //移除两个以上的空格
                text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");        //移除Br
                text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");        //移除&nbsp;
                text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);        //移除其他一些标志
                text = text.Replace("'", "''");//防止注入
                return text;
            }

            /// <summary> 客户端输入字符串验证</summary>
            /// <param name="text">客户端输入字符串</param>
            /// <returns>清理后的字符串</returns>
            public static string ClearInputText(string text)
            {
                if (string.IsNullOrEmpty(text))
                    return string.Empty;
                text = text.Trim();
                if (string.IsNullOrEmpty(text))
                    return string.Empty;
                text = Regex.Replace(text, "[\\s]{2,}", " ");        //移除两个以上的空格
                text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");        //移除Br
                text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");        //移除&nbsp;
                text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);        //移除其他一些标志
                text = text.Replace("'", "''");//防止注入
                return text;
            }

            /// <summary> 检测是否有Sql危险字符</summary>
            /// <param name="str">要判断字符串</param>
            /// <returns>判断结果</returns>
            public static bool IsSafeSqlString(string str)
            {
                return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
            }

            /// <summary> 替换SQL危险字符</summary>
            /// <param name="s"></param>
            /// <returns></returns>
            public static string SafeSql(string s)
            {
                string str = string.Empty;
                if (s != null)
                {
                    str = s.Replace("'", "''");
                }
                return str.Trim();
            }

            /// <summary> 从左边截取字符串,已进行空值判断</summary>
            /// <param name="s">待截取的字符串</param>
            /// <param name="len">要截取的长度</param>
            /// <returns></returns>
            public static string Left(string s, int len)
            {
                if (string.IsNullOrEmpty(s))
                {
                    return string.Empty;
                }
                else
                {
                    if (s.Length <= len)
                        return s;
                    else
                        return s.Substring(0, len);
                }
            }

            public static string GetMD5(string input, string charset)
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] data = md5.ComputeHash(Encoding.GetEncoding(charset).GetBytes(input));
                StringBuilder builder = new StringBuilder(32);
                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }
                return builder.ToString();
            }

            /// Int转化
            /// <summary>
            /// Int转化
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public static int ToInt(this string str)
            {
                int result = 0;
                int.TryParse(str, out result);
                return result;
            }


            /// <summary>
            /// 对象为空抛自定义异常
            /// </summary>
            /// <typeparam name="T">类型</typeparam>
            /// <param name="obj">对象</param>
            /// <param name="errMsg">自定义错误信息</param>
            public static void IsNullThrowException<T>(this T obj, string errMsg = "对象为空")
            {
                if (obj == null)
                {
                    throw new Exception(errMsg);
                }
            }

            /// <summary>
            /// 对象为空
            /// </summary>
            /// <typeparam name="T">类型</typeparam>
            /// <param name="obj">对象</param>
            /// <returns>true or false</returns>
            public static bool IsNull<T>(this T obj)
            {
                if (obj == null)
                {
                    return true;
                }

                return false;
            }

            /// <summary>
            /// 对象不为空
            /// </summary>
            /// <typeparam name="T">类型</typeparam>
            /// <param name="obj">对象</param>
            /// <returns>true or false</returns>
            public static bool IsNotNull<T>(this T obj)
            {
                if (obj != null)
                {
                    return true;
                }

                return false;
            }
            /// <summary>
            /// 集合为空或不包含任何数据，则抛出异常
            /// </summary>
            /// <typeparam name="T">类型</typeparam>
            /// <param name="objs">数据集合</param>
            /// <param name="errMsg">自定义异常信息</param>
            public static void IsNotAnyThrowException<T>(this List<T> objs, string errMsg = "集合为空或不包含任何数据")
            {
                if (objs == null || !objs.Any())
                {
                    throw new Exception(errMsg);
                }
            }

            /// <summary>
            /// 集合不为空且包含数据
            /// </summary>
            /// <typeparam name="T">类型</typeparam>
            /// <param name="objs">数据集合</param>
            /// <returns>true or false</returns>
            public static bool IsAny<T>(this List<T> objs)
            {
                if (objs != null && objs.Any())
                {
                    return true;
                }

                return false;
            }

            /// <summary>
            /// 集合为空或者集合中不包含数据
            /// </summary>
            /// <typeparam name="T">类型</typeparam>
            /// <param name="objs">数据集合</param>
            /// <returns>true or false</returns>
            public static bool IsNotAny<T>(this List<T> objs)
            {
                if (objs == null || !objs.Any())
                {
                    return true;
                }

                return false;
            }

            /// <summary>
            /// 集合为空或不包含任何数据，则抛出异常
            /// </summary>
            /// <typeparam name="TKey">类型</typeparam>
            /// <typeparam name="TValue">值</typeparam>
            /// <param name="objs">数据集合</param>
            /// <param name="errMsg">自定义异常信息</param>
            public static void IsNotAnyThrowException<TKey, TValue>(this Dictionary<TKey, TValue> objs, string errMsg = "集合为空或不包含任何数据")
            {
                if (objs == null || !objs.Any())
                {
                    throw new Exception(errMsg);
                }
            }

            /// <summary>
            /// 集合不为空且包含数据
            /// </summary>
            /// <typeparam name="TKey">类型</typeparam>
            /// <typeparam name="TValue">值</typeparam>
            /// <param name="objs">数据集合</param>
            /// <returns>true or false</returns>
            public static bool IsAny<TKey, TValue>(this Dictionary<TKey, TValue> objs)
            {
                if (objs != null && objs.Any())
                {
                    return true;
                }

                return false;
            }

            /// <summary>
            /// 集合为空或者集合中不包含数据
            /// </summary>
            /// <typeparam name="TKey">类型</typeparam>
            /// <typeparam name="TValue">值</typeparam>
            /// <param name="objs">数据集合</param>
            /// <returns>true or false</returns>
            public static bool IsNotAny<TKey, TValue>(this Dictionary<TKey, TValue> objs)
            {
                if (objs == null || !objs.Any())
                {
                    return true;
                }

                return false;
            }
            /// <summary>
            /// 集合
            /// </summary>
            /// <typeparam name="TValue">类型</typeparam>
            /// <typeparam name="TKey">值</typeparam>
            /// <param name="objs">数据集合</param>
            /// <param name="key">key值</param>
            /// <returns></returns>
            public static TValue GetValueOrDefault<TValue, TKey>(this Dictionary<TKey, TValue> dictionary, TKey key)
            {
                return dictionary.ContainsKey(key) ? dictionary[key] : default(TValue);
            }

            public static Dictionary<TKey, TValue> AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> values, bool replaceExisted)
            {
                foreach (KeyValuePair<TKey, TValue> keyValuePair in values)
                {
                    if (!dict.ContainsKey(keyValuePair.Key) || replaceExisted)
                        dict[keyValuePair.Key] = keyValuePair.Value;
                }
                return dict;
            }


            /// <summary>
            /// 空或无
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public static string ToYYYYMMDDHHmmssString(this DateTime value)
            {
                return value.ToString("yyyy-MM-dd HH:mm:ss");
            }

            /// <summary>
            /// 空或无
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public static bool IsNullOrEmpty(this string value)
            {
                return string.IsNullOrEmpty(value);
            }

            /// <summary>
            /// 时间类型转yyyy-MM-dd HH:mm:ss.fff格式字符串
            /// </summary>
            /// <param name="time">时间</param>
            /// <returns>字符串</returns>
            public static string ToMillisecondString(this DateTime time)
            {
                return time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            }
        }
    }