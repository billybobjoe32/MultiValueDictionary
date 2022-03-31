using MultiValueDictionaryApp;
using NUnit.Framework;

namespace MultiValueDictionaryTests
{
    public class AppTests
    {
        public static MultiValueDictionary InitializeClass()
        {
            MultiValueDictionary mvd = new MultiValueDictionary();
            mvd.Dictionary.Add("foo", new System.Collections.Generic.List<string> { "bar"});
            return mvd;
        }

        [Test]
        public void NullInput()
        {
            MultiValueDictionary mvp = new MultiValueDictionary();
            string output = mvp.ProcessRequest(null);
            Assert.AreEqual(") Command not recognized, please try again.", output);
        }
        [Test]
        public void InvalidInput()
        {
            MultiValueDictionary mvp = new MultiValueDictionary();
            string output = mvp.ProcessRequest("something");
            Assert.AreEqual(") Command not recognized, please try again.", output);
        }
        [Test]
        public void QuitRequestGood()
        {
            MultiValueDictionary mvp = new MultiValueDictionary();
            string output = mvp.ProcessRequest("quit");
            Assert.AreEqual(") Thanks for using the MultiValueDictionary app!", output);
        }
    }
}