using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rob;
using rob.API.ApacheISISApi;
using rob.layout.representations;

namespace unittests
{
    [TestClass]
    public class FieldSetLayoutFilterTests:UnitTestBase
    {
        private IsisSingleObject _iso;

        [TestInitialize]
        public void Setup()
        {
            _iso = LoadIsisObject();
            var raw = System.IO.File.ReadAllText("data/layout.json");
            System.Text.Json.JsonSerializer.Deserialize<ObjectLayout>(raw);
        }
        
        [TestMethod]
        public void Properties()
        {
            var iso = LoadIsisObject();
            var raw = System.IO.File.ReadAllText("data/layout.json");
            var layout = System.Text.Json.JsonSerializer.Deserialize<ObjectLayout>(raw);
            
            var fieldSet = layout.row[1].cols[0].col.tabGroup[0].tab[0].row[0].cols[0].col.fieldSet[0];

            var sut = new FieldSetLayoutFilter(iso, fieldSet);
            
            Assert.AreEqual(3,fieldSet.property.Length);
            Assert.AreEqual(6,iso.ro.Properties.Count());
            Assert.AreEqual(3,sut.Properties.Count());
        }
        
        [TestMethod]
        public void Actions()
        {
            var iso = LoadIsisObject();
            var raw = System.IO.File.ReadAllText("data/layout.json");
            var layout = System.Text.Json.JsonSerializer.Deserialize<ObjectLayout>(raw);
            
            var fieldSet = layout.row[1].cols[0].col.tabGroup[0].tab[0].row[0].cols[0].col.fieldSet[0];

            var sut = new FieldSetLayoutFilter(iso, fieldSet);
            
            Assert.AreEqual(3,fieldSet.action.Length);
            Assert.AreEqual(8,iso.ro.Actions.Count());
            Assert.AreEqual(3,sut.Actions.Count());
        }
        [TestMethod]
        public void DealWithNoLayouActions()
        {
            var iso = LoadIsisObject();
            var raw = System.IO.File.ReadAllText("data/layout.json");
            var layout = System.Text.Json.JsonSerializer.Deserialize<ObjectLayout>(raw);
            
            var tab = layout.row[1].cols[0].col.tabGroup[0].tab[1];
            
            var fieldSet = tab.row[0].cols[0].col.fieldSet[0];
            
            new FieldSetLayoutFilter(iso, fieldSet);
        }
    }
}