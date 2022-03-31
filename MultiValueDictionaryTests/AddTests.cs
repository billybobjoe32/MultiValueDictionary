using MultiValueDictionaryApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionaryTests
{
    public class AddTests
    {
        [Test]
        public void AddRequestGood()
        {
            MultiValueDictionary mvp = new MultiValueDictionary();
            string output = mvp.ProcessRequest("add foo bar");
            Assert.IsTrue(mvp.Dictionary.ContainsKey("foo") && mvp.Dictionary["foo"].Contains("bar") && output == "Added");
        }
        [Test]
        public void AddRequestValueAlreadyExists()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            string output = mvp.ProcessRequest("add foo bar");
            Assert.AreEqual("ERROR, member already exists for key", output);
        }
        [Test]
        public void AddRequestWrongParameters()
        {
            MultiValueDictionary mvp = new MultiValueDictionary();
            string output = mvp.ProcessRequest("add foo");
            Assert.AreEqual("ADD command only allows for two parameters", output);
        }
    }
}
