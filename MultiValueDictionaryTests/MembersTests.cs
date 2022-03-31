using MultiValueDictionaryApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionaryTests
{
    public class MembersTests
    {
        [Test]
        public void MembersRequestEmpty()
        {
            MultiValueDictionary mvp = new MultiValueDictionary();
            string output = mvp.ProcessRequest("members foo");
            Assert.AreEqual("ERROR, key does not exist.", output);
        }
        [Test]
        public void MembersRequestValue()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            mvp.ProcessRequest("add foo baz");
            string output = mvp.ProcessRequest("members foo");
            Assert.AreEqual("1) bar\r\n2) baz", output);
        }
        [Test]
        public void MembersWrongParameters()
        {
            MultiValueDictionary mvp = new MultiValueDictionary();
            string output = mvp.ProcessRequest("members foo bar");
            Assert.AreEqual("MEMBERS command only allows for one parameter", output);
        }
    }
}
