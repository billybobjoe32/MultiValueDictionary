using MultiValueDictionaryApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionaryTests
{
    public class AllMembersTests
    {
        [Test]
        public void AllMembersRequestGood()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            mvp.ProcessRequest("add foo baz");
            mvp.ProcessRequest("add bang bar");
            mvp.ProcessRequest("add bang baz");
            string output = mvp.ProcessRequest("allmembers");
            Assert.AreEqual("1) bar\r\n2) baz\r\n3) bar\r\n4) baz", output);
        }
        [Test]
        public void AllMembersRequestEmptySet()
        {
            MultiValueDictionary mvp = new MultiValueDictionary();
            string output = mvp.ProcessRequest("allmembers");
            Assert.AreEqual("empty set", output);
        }
    }
}
