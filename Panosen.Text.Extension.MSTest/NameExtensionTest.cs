using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.Text.Extension.MSTest
{
    [TestClass]
    public class NameExtensionTest
    {
        [TestMethod]
        public void ToUpperCaseUnderLine()
        {
            Assert.AreEqual("ZHANG_SAN", "ZhangSan".ToUpperCaseUnderLine());
            Assert.AreEqual("ZHANG_SAN", "zhang-san".ToUpperCaseUnderLine());
            Assert.AreEqual("ZHANG_SAN", "zhang_san".ToUpperCaseUnderLine());

            Assert.AreEqual("ZHANG_SAN_111", "ZhangSan111".ToUpperCaseUnderLine());
            Assert.AreEqual("ZHANG_222_SAN", "Zhang222San".ToUpperCaseUnderLine());
            Assert.AreEqual("ZHANG_333_SAN", "Zhang333san".ToUpperCaseUnderLine());

            Assert.AreEqual("NGRAM_3", "NGRAM_3".ToUpperCaseUnderLine());

            Assert.AreEqual("SSL", "SSL".ToUpperCaseUnderLine());
            Assert.AreEqual("SSL", "ssl".ToUpperCaseUnderLine());
        }

        [TestMethod]
        public void ToLowerCaseUnderLine()
        {
            Assert.AreEqual("zhang_san", "ZhangSan".ToLowerCaseUnderLine());
            Assert.AreEqual("zhang_san", "zhang-san".ToLowerCaseUnderLine());
            Assert.AreEqual("zhang_san", "zhang_san".ToLowerCaseUnderLine());

            Assert.AreEqual("zhang_san_444", "ZhangSan444".ToLowerCaseUnderLine());
            Assert.AreEqual("zhang_555_san", "Zhang555San".ToLowerCaseUnderLine());
            Assert.AreEqual("zhang_666_san", "Zhang666san".ToLowerCaseUnderLine());

            Assert.AreEqual("ngram_3", "ngram_3".ToLowerCaseUnderLine());

            Assert.AreEqual("ssl", "SSL".ToLowerCaseUnderLine());
            Assert.AreEqual("ssl", "ssl".ToLowerCaseUnderLine());
        }

        [TestMethod]
        public void ToLowerCaseBreakLine()
        {
            Assert.AreEqual("zhang-san", "ZhangSan".ToLowerCaseBreakLine());
            Assert.AreEqual("zhang-san", "zhang-san".ToLowerCaseBreakLine());
            Assert.AreEqual("zhang-san", "zhang-san".ToLowerCaseBreakLine());

            Assert.AreEqual("zhang-san-444", "ZhangSan444".ToLowerCaseBreakLine());
            Assert.AreEqual("zhang-555-san", "Zhang555San".ToLowerCaseBreakLine());
            Assert.AreEqual("zhang-666-san", "Zhang666san".ToLowerCaseBreakLine());

            Assert.AreEqual("ngram-3", "ngram-3".ToLowerCaseBreakLine());

            Assert.AreEqual("ssl", "SSL".ToLowerCaseBreakLine());
            Assert.AreEqual("ssl", "ssl".ToLowerCaseBreakLine());
        }

        [TestMethod]
        public void ToUpperCamelCase()
        {
            Assert.AreEqual("ZhangSan", "ZhangSan".ToUpperCamelCase());
            Assert.AreEqual("ZhangSan", "zhang-san".ToUpperCamelCase());
            Assert.AreEqual("ZhangSan", "zhang-san".ToUpperCamelCase());

            Assert.AreEqual("ZhangSan444", "ZhangSan444".ToUpperCamelCase());
            Assert.AreEqual("Zhang555San", "Zhang555San".ToUpperCamelCase());
            Assert.AreEqual("Zhang666San", "Zhang666san".ToUpperCamelCase());

            Assert.AreEqual("Ngram3", "ngram-3".ToUpperCamelCase());

            Assert.AreEqual("Ssl", "SSL".ToUpperCamelCase());
            Assert.AreEqual("Ssl", "ssl".ToUpperCamelCase());
        }

        [TestMethod]
        public void ToLowerCamelCase()
        {
            Assert.AreEqual("zhangSan", "ZhangSan".ToLowerCamelCase());
            Assert.AreEqual("zhangSan", "zhang-san".ToLowerCamelCase());
            Assert.AreEqual("zhangSan", "zhang-san".ToLowerCamelCase());

            Assert.AreEqual("zhangSan444", "ZhangSan444".ToLowerCamelCase());
            Assert.AreEqual("zhang555San", "Zhang555San".ToLowerCamelCase());
            Assert.AreEqual("zhang666San", "Zhang666san".ToLowerCamelCase());

            Assert.AreEqual("ngram3", "ngram-3".ToLowerCamelCase());

            Assert.AreEqual("ssl", "SSL".ToLowerCamelCase());
            Assert.AreEqual("ssl", "ssl".ToLowerCamelCase());
        }
    }
}
