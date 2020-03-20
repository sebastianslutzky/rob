using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace rob.representations.tests.unitTests
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