using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using rob.API.ApacheISISApi;

namespace unittests.representations
{
    [TestClass]
    public class IsisSingleObjectTests : UnitTestBase
    {
        [TestMethod]
        public void ISO_Deserialization()
        {
            var iso = LoadIsisSingleObject();
            Assert.IsNotNull(iso);
        }
        [TestMethod]
        public void ISO_ro()
        {
            var iso = LoadIsisSingleObject();
            Assert.IsNotNull(iso.ro);
        }
     
  
   
    }
}