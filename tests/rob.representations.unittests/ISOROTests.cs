using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace unittests.representations
{
    [TestClass]
    public class ISOROTests : UnitTestBase
    {
        [TestMethod]
        public void ISO_Deserialization()
        {
            var iso = LoadIsisSingleObject();
            Assert.IsNotNull(iso);
        }
        [TestMethod]
        public void ro_member()
        {
            var iso = LoadIsisSingleObject();
            Assert.AreEqual("company",iso.ro.members.ElementAt(0).Value.id);
        }
        
        [TestMethod]
        public void ro_actions()
        {
            var iso = LoadIsisSingleObject();
            var actions = iso.ro.Actions;
            
            Assert.AreEqual(8,actions.Count());
        }
        [TestMethod]
        public void ro_properties()
        {
            var iso = LoadIsisSingleObject();
            var props = iso.ro.Properties;
            
            Assert.AreEqual(6,props.Count());
        }
        
        [TestMethod]
        public void ro_members()
        {
            var iso = LoadIsisSingleObject();
            Assert.IsNotNull(iso.ro.members);
            Assert.AreEqual(16,iso.ro.members.Count);
        }
        [TestMethod]
        public void ro_links()
        {
            var iso = LoadIsisSingleObject();
            Assert.IsNotNull(iso.ro.Links);
            Assert.AreEqual(5,iso.ro.Links.Length);
        }
    }
}