using MultiValueDictionaryApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionaryTests
{
    public class MemberExistsTests
    {
        [Test]
        public void MemberExistsRequestTrue()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            string output = mvp.ProcessRequest("memberexists foo bar");
            Assert.AreEqual(") true", output);
        }
        [Test]
        public void MemberExistsRequestFalse()
        {
            MultiValueDictionary mvp = AppTests.InitializeClass();
            string output = mvp.ProcessRequest("memberexists doo bar");
            Assert.AreEqual(") false", output);
        }
        [Test]
        public void MemberRequestWrongParameters()
        {
            MultiValueDictionary mvp = new MultiValueDictionary();
            string output = mvp.ProcessRequest("memberexists too");
            Assert.AreEqual(") MEMBEREXISTS command only allows for two parameters", output);
        }
    }
}
