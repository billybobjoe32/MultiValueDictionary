using MultiValueDictionaryApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionaryTests
{
    public class KeyExistsTests
    {
        [Test]
        public void KeyExistsRequestTrue()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            string output = mvp.ProcessRequest("keyexists foo");
            Assert.AreEqual(") true", output);
        }
        [Test]
        public void KeyExistsRequestFalse()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            string output = mvp.ProcessRequest("keyexists doo");
            Assert.AreEqual(") false", output);
        }
        [Test]
        public void KeyExistsRequestWrongParameters()
        {
            MultiValueDictionary mvp = new MultiValueDictionary();
            string output = mvp.ProcessRequest("keyexists foo too");
            Assert.AreEqual(") KEYEXISTS command only allows for one parameter", output);
        }
    }
}
