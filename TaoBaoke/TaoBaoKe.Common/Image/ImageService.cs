using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBaoKe.Common.Image
{
    /// <summary>
    /// 图片操作类
    /// </summary>
    public class ImageService
    {
        /// <summary>
        /// 根据图片路径获取对应图片的Base64流
        /// </summary>
        /// <param name="imagefilePath"></param>
        /// <returns></returns>
        public string GetBase64FromImagePath(string imagefilePath)
        {
            string strbaser64 = "";
            try
            {
                Bitmap bmp = new Bitmap(imagefilePath);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                strbaser64 = Convert.ToBase64String(arr);
            }
            catch (Exception)
            {
                throw new Exception("Something wrong during convert!");
            }
            return strbaser64;
        }

        /// <summary>
        /// 根据图片路径获取对应图片的Base64流
        /// </summary>
        /// <param name="imagefilePath"></param>
        /// <returns></returns>
        public string GetBase64FromImageStream(Stream stream)
        {
            string strbaser64 = "";
            try
            {
                Bitmap bmp = new Bitmap(stream);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                strbaser64 = Convert.ToBase64String(arr);
            }
            catch (Exception)
            {
                throw new Exception("Something wrong during convert!");
            }
            return strbaser64;
        }
    }
}
