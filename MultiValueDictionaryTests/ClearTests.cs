using MultiValueDictionaryApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionaryTests
{
    internal class ClearTests
    {
        [Test]
        public void ClearRequestGood()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            string output = mvp.ProcessRequest("clear");
            Assert.AreEqual("Cleared", output);
            Assert.IsTrue(mvp.Dictionary.Count == 0);
        }
    }
}
