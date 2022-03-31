using MultiValueDictionaryApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionaryTests
{
    public class KeysTests
    {
        [Test]
        public void KeysRequestEmpty()
        {
            MultiValueDictionary mvp = new MultiValueDictionary();
            string output = mvp.ProcessRequest("keys");
            Assert.AreEqual("(empty set)", output);
        }
        [Test]
        public void KeysRequestValue()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            string output = mvp.ProcessRequest("keys");
            Assert.AreEqual("1) foo", output);
        }
    }
}
