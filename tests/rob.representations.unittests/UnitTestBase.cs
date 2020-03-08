using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using rob.API.ApacheISISApi;

namespace unittests
{
    public class UnitTestBase
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        
        

        protected IsisSingleObject LoadIsisObject()
        {
            var fileName = Directory.GetCurrentDirectory();
            var raw = System.IO.File.ReadAllText("data/contact.json");

            var obj = JObject.Parse(raw);
            var isisObj = new IsisSingleObject(obj);
            return isisObj;
        }
    }
}