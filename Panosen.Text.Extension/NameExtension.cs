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
            List<string> items = ToItems(name);

            return string.Join("_", items).ToUpper();
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
        /// 将数据库表名转换成实体名称
        /// 示例：student_score -> StudentScore
        /// </summary>
        public static string ToUpperCamelCase(this string name)
        {
            var items = ToItems(name);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < items.Count; i++)
            {
                builder.Append(items[i][0].ToString().ToUpper() + items[i].Substring(1));
            }

            return builder.ToString();
        }

        /// <summary>
        /// 由Name计算而来
        /// 示例：name, studentScore
        /// </summary>
        public static string ToLowerCamelCase(this string name)
        {
            var items = ToItems(name);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < items.Count; i++)
            {
                if (i == 0)
                {
                    builder.Append(items[i]);
                }
                else
                {
                    builder.Append(items[i][0].ToString().ToUpper() + items[i].Substring(1));
                }
            }

            return builder.ToString();
        }

        private static CharType ToCharType(char ch)
        {
            if (ch >= 'A' && ch <= 'Z')
            {
                return CharType.UpperLetter;
            }
            if (ch >= 'a' && ch <= 'z')
            {
                return CharType.LowerLetter;
            }
            if (ch >= '0' && ch <= '9')
            {
                return CharType.Number;
            }
            if (ch == '-')
            {
                return CharType.BreakLine;
            }
            if (ch == '_')
            {
                return CharType.UnderLine;
            }
            return CharType.None;
        }

        /// <summary>
        /// 拆分字符串
        /// </summary>
        private static List<string> ToItems(string text)
        {
            List<string> items = new List<string>();
            StringBuilder builder = new StringBuilder();

            Item lastItem = null;

            for (int i = 0; i < text.Length; i++)
            {
                var currentItem = new Item { Ch = text[i], Type = ToCharType(text[i]) };

                if (lastItem == null)
                {
                    builder.Append(currentItem.Ch);

                    lastItem = currentItem;
                    continue;
                }

                if (currentItem.Type == CharType.BreakLine || currentItem.Type == CharType.UnderLine)
                {
                    if (builder.Length > 0)
                    {
                        items.Add(builder.ToString().ToLower());
                        builder.Clear();
                    }

                    lastItem = currentItem;
                    continue;
                }

                if (lastItem.Type == CharType.LowerLetter && currentItem.Type == CharType.UpperLetter)
                {
                    items.Add(builder.ToString().ToLower());
                    builder.Clear();

                    builder.Append(currentItem.Ch);

                    lastItem = currentItem;
                    continue;
                }

                if (lastItem.Type == CharType.UpperLetter && currentItem.Type == CharType.LowerLetter)
                {
                    builder.Append(currentItem.Ch);

                    lastItem = currentItem;
                    continue;
                }

                if (lastItem.Type != currentItem.Type)
                {
                    items.Add(builder.ToString().ToLower());
                    builder.Clear();

                    builder.Append(currentItem.Ch);

                    lastItem = currentItem;
                    continue;
                }

                builder.Append(currentItem.Ch);

                lastItem = currentItem;
            }

            items.Add(builder.ToString().ToLower());

            items = items.Where(v => v.Length > 0).ToList();
            return items;
        }
    }
}
