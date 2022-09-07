using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Text.Extension.MSTest
{
    [TestClass]
    public class UnicodeExtensionTest
    {
        [TestMethod]
        public void TestToUnicode()
        {
            Assert.AreEqual("\\u0031", "1".ToUnicode(UnicodeFormat.Simple));
            Assert.AreEqual("\\u0032", "2".ToUnicode(UnicodeFormat.Simple));
            Assert.AreEqual("\\u0031\\u0032", "12".ToUnicode(UnicodeFormat.Simple));

            Assert.AreEqual("&#x0031;", "1".ToUnicode(UnicodeFormat.Complex));
            Assert.AreEqual("&#x0032;", "2".ToUnicode(UnicodeFormat.Complex));
            Assert.AreEqual("&#x0031;&#x0032;", "12".ToUnicode(UnicodeFormat.Complex));
        }

        [TestMethod]
        public void TestFromUnicode()
        {
            Assert.AreEqual("1", "\\u0031".FromUnicode());
            Assert.AreEqual("2", "\\u0032".FromUnicode());
            Assert.AreEqual("12", "\\u0031\\u0032".FromUnicode());

            Assert.AreEqual("1", "&#x0031;".FromUnicode());
            Assert.AreEqual("2", "&#x0032;".FromUnicode());
            Assert.AreEqual("12", "&#x0031;&#x0032;".FromUnicode());

            Assert.AreEqual("12", "&#x31;&#x32;".FromUnicode());
        }
    }
}
