using System.ComponentModel;

namespace TaoBaoKe.Entity.Enum
{
    public class BaiDuWordEnum
    {

        public enum CustomTemplate
        {
            /// <summary>
            /// 身份证正面
            /// </summary>
            [Description("388cdc11329007e93084ea845b1f273b")]
            身份证正面 = 1,
            /// <summary>
            /// 身份证背面
            /// </summary>
            [Description("9ab87da180ceb262f62c128935d61f2f")]
            身份证背面 = 2,
            /// <summary>
            /// 护照
            /// </summary>
            [Description("e8aed3ff033e475be36ce2bf673d8186")]
            护照 =3
        }
    }
}
