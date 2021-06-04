using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.Text.Extension.MSTest
{
    [TestClass]
    public class NameExtensionTest
    {
        [TestMethod]
        public void ToLowerCaseUnderLine()
        {
            Assert.AreEqual("ZhangSan".ToLowerCaseUnderLine(), "zhang_san");
        }

        [TestMethod]
        public void ToLowerCaseUnderLine2()
        {
            Assert.AreEqual("ZhangSan123".ToLowerCaseUnderLine(), "zhang_san_123");
        }

        [TestMethod]
        public void ToLowerCaseUnderLine3()
        {
            Assert.AreEqual("ngram_3".ToLowerCaseUnderLine(), "ngram_3");
        }

        [TestMethod]
        public void ToLowerCaseUnderLine4()
        {
            Assert.AreEqual("SSL".ToLowerCaseUnderLine(), "ssl");
        }

        [TestMethod]
        public void ToLowerCamelCase()
        {
            Assert.AreEqual("SSL".ToLowerCamelCase(), "sSL");
        }
    }
}
