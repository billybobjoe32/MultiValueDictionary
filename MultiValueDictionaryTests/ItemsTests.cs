using MultiValueDictionaryApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionaryTests
{
    public class ItemsTests
    {
        [Test]
        public void ItemsRequestGood()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            mvp.ProcessRequest("add foo baz");
            mvp.ProcessRequest("add bang bar");
            mvp.ProcessRequest("add bang baz");
            string output = mvp.ProcessRequest("items");
            Assert.AreEqual("1) foo: bar\r\n2) foo: baz\r\n3) bang: bar\r\n4) bang: baz", output);
        }
        [Test]
        public void ItemsRequestEmptySet()
        {
            MultiValueDictionary mvp = new MultiValueDictionary();
            string output = mvp.ProcessRequest("items");
            Assert.AreEqual("empty set", output);
        }
    }
}
