using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestfulObjectApi.Representation.Types;

namespace unittests.representations
{
    [TestClass]
    public class MembersTests : UnitTestBase
    {
        [TestMethod]
        public void Value()
        {
            var iso = LoadIsisSingleObject();
            var ro = iso.ro.members;
            
            Assert.IsNotNull(ro["company"]);
            Assert.AreEqual("Cumba",ro["company"].value);
        }
    }
    
    [TestClass]
    public class PropertyTests : UnitTestBase
    {
        [TestMethod]
        public void Deserialize()
        {
            var raw = System.IO.File.ReadAllText("data/property.json");
            var layout = System.Text.Json.JsonSerializer.Deserialize<ObjectMemberInstance>(raw);
        }
    } 
}