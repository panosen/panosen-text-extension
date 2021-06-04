using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// string 扩展，用于改变名字
    /// </summary>
    public static class NameExtension
    {
        /// <summary>
        /// 小写的名称，由Name计算而来
        /// 示例：Student -> STUDENT
        /// 示例：StudentScore -> STUDENT_SCORE
        /// </summary>
        public static string ToUpperCaseUnderLine(this string name)
        {
            return ToLowerCaseUnderLine(name).ToUpper();
        }

        /// <summary>
        /// 小写的名称，由Name计算而来
        /// 示例：Student -> student
        /// 示例：StudentScore -> student_score
        /// </summary>
        public static string ToLowerCaseUnderLine(this string name)
        {
            List<string> items = ToItems(name);

            return string.Join("_", items);
        }

        /// <summary>
        /// 小写的名称，由Name计算而来
        /// 示例：Student -> student
        /// 示例：StudentScore -> student-score
        /// </summary>
        public static string ToLowerCaseBreakLine(this string name)
        {
            List<string> items = ToItems(name);

            return string.Join("-", items);
        }

        /// <summary>
        /// 拆分字符串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static List<string> ToItems(string name)
        {
            List<string> items = new List<string>();
            StringBuilder item = new StringBuilder();

            char? last = null;

            for (int i = 0; i < name.Length; i++)
            {
                var ch = name[i];

                if (ch >= 'A' && ch <= 'Z' && last != null && (last < 'A' || last > 'Z'))
                {
                    items.Add(item.ToString());
                    item.Clear();

                    item.Append((char)(ch + 32));
                }
                else if (ch >= '0' && ch <= '9' && last != null && (last < '0' || last > '9'))
                {
                    items.Add(item.ToString());
                    item.Clear();

                    item.Append(ch);
                }
                else if (ch == '_' || ch == '-')
                {
                    items.Add(item.ToString());
                    item.Clear();
                }
                else
                {
                    item.Append(ch.ToString().ToLower());
                }

                last = ch;
            }

            items.Add(item.ToString());

            items = items.Where(v => v.Length > 0).ToList();
            return items;
        }

        /// <summary>
        /// 将数据库表名转换成实体名称
        /// 示例：student_score -> StudentScore
        /// </summary>
        public static string ToUpperCamelCase(this string name)
        {
            bool toUpper = true;

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                var current = name[i];
                if (current == '_')
                {
                    toUpper = true;
                    continue;
                }

                if (toUpper && current >= 'a' && current <= 'z')
                {
                    builder.Append((char)(current - 32));
                    toUpper = false;
                }
                else
                {
                    builder.Append(current);
                    toUpper = false;
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// 由Name计算而来
        /// 示例：name, studentScore
        /// </summary>
        public static string ToLowerCamelCase(this string name)
        {
            return name[0].ToString().ToLower() + name.Substring(1);
        }
    }
}
