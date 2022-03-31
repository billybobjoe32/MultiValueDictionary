using MultiValueDictionaryApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionaryTests
{
    internal class RemoveTests
    {
        [Test]
        public void RemoveRequestGoodRemovedMember()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            mvp.ProcessRequest("add foo baz");
            string output = mvp.ProcessRequest("remove foo bar");
            Assert.AreEqual("Removed", output);
            Assert.IsTrue(!mvp.Dictionary["foo"].Contains("bar"));
        }
        [Test]
        public void RemoveRequestGoodRemovedKeyAndMember()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            string output = mvp.ProcessRequest("remove foo bar");
            Assert.AreEqual("Removed", output);
            Assert.IsTrue(!mvp.Dictionary.ContainsKey("foo"));
        }
        [Test]
        public void RemoveRequestKeyDoesNotExist()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            string output = mvp.ProcessRequest("remove doo bar");
            Assert.AreEqual("ERROR, key does not exist.", output);
        }
        [Test]
        public void RemoveRequestMemberDoesNotExist()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            string output = mvp.ProcessRequest("remove foo baz");
            Assert.AreEqual("ERROR, member does not exist.", output);
        }
        [Test]
        public void RemoveRequestWrongParameters()
        {
            MultiValueDictionary mvp = new MultiValueDictionary();
            string output = mvp.ProcessRequest("remove foo");
            Assert.AreEqual("REMOVE command only allows for two parameters", output);
        }
    }
}
