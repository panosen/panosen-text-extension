using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Text.Extension
{
    /// <summary>
    /// Unicode格式
    /// </summary>
    public enum UnicodeFormat
    {
        /// <summary>
        /// \u0000
        /// </summary>
        Simple,

        /// <summary>
        /// &amp;#x0000;
        /// </summary>
        Complex
    }

    /// <summary>
    /// Unicode编解码相关
    /// </summary>
    public static class UnicodeExtension
    {
        /// <summary>
        /// 字符串转Unicode字符串
        /// 示例：1 => \u0031
        /// </summary>
        public static string ToUnicode(this string text, UnicodeFormat format = UnicodeFormat.Simple)
        {
            var bytes = Encoding.Unicode.GetBytes(text);
            var builder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i += 2)
            {
                switch (format)
                {
                    case UnicodeFormat.Complex:
                        {
                            builder.AppendFormat("&#x{0:x2}{1:x2};", bytes[i + 1], bytes[i]);
                        }
                        break;
                    case UnicodeFormat.Simple:
                    default:
                        {
                            builder.AppendFormat("\\u{0:x2}{1:x2}", bytes[i + 1], bytes[i]);
                        }
                        break;
                }

            }
            return builder.ToString();
        }

        /// <summary>  
        /// Unicode字符串转为正常字符串
        /// 示例：\u0031 => 1
        /// </summary>
        public static string FromUnicode(this string text)
        {
            StringBuilder builder = new StringBuilder();

            var items = text.Split(new string[] { "\\u", "&#x", ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items)
            {
                var ch = (char)int.Parse(item, System.Globalization.NumberStyles.HexNumber);
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
