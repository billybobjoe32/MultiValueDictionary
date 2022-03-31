using MultiValueDictionaryApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionaryTests
{
    public class RemoveAllTests
    {
        [Test]
        public void RemoveAllRequestGood()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            mvp.ProcessRequest("add foo baz");
            string output = mvp.ProcessRequest("removeall foo");
            Assert.AreEqual(") Removed", output);
            Assert.IsTrue(!mvp.Dictionary.ContainsKey("foo"));
        }
        [Test]
        public void RemoveAllRequestKeyDoesNotExist()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            string output = mvp.ProcessRequest("removeall doo");
            Assert.AreEqual(") ERROR, key does not exist.", output);
        }
        [Test]
        public void RemoveAllRequestWrongParameters()
        {
            MultiValueDictionary mvp = new MultiValueDictionary();
            string output = mvp.ProcessRequest("removeall foo too");
            Assert.AreEqual(") REMOVEALL command only allows for one parameter", output);
        }
    }
}
