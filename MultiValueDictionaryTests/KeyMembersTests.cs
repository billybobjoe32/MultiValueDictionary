using MultiValueDictionaryApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionaryTests
{
    public class KeyMembersTests
    {
        [Test]
        public void KeyMembersRequestGood()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            mvp.ProcessRequest("add foo baz");
            mvp.ProcessRequest("add bang bar");
            mvp.ProcessRequest("add bang baz");
            mvp.ProcessRequest("add zoo party");
            mvp.ProcessRequest("add ring bell");
            string output = mvp.ProcessRequest("keymembers foo bang");
            output = output.Replace("\r", "");
            output = output.Replace("\n", "");
            Assert.AreEqual("1) foo: bar2) foo: baz3) bang: bar4) bang: baz", output);
        }
        [Test]
        public void KeyMembersRequestEmptySet()
        {
            MultiValueDictionary mvp = new MultiValueDictionary();
            string output = mvp.ProcessRequest("keymembers foo");
            Assert.AreEqual("(empty set)", output);
        }
        [Test]
        public void KeyMembersRequestWrongParameters()
        {
            MultiValueDictionary mvp = new MultiValueDictionary();
            string output = mvp.ProcessRequest("keymembers");
            Assert.AreEqual(") KEYMEMBERS command has to have at least one parameter", output);
        }
    }
}
