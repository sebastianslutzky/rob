using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using rob.API.ApacheISISApi;
using rob.API.ApacheISISApi.Resources;

namespace rob.representations.tests.unitTests.IsisResourceDeserialization
{
    [TestClass]
    public class CollectionSearchResults
    {
        private SimpleIsisCollection _converted;

        [TestInitialize]
        public void Setup()
        {
            var raw = File.ReadAllText("data/collectionDetails.json");
            _converted = JsonConvert.DeserializeObject<SimpleIsisCollection>(raw, new IsisResourceConverter());
        }

        [TestMethod]
        public void Items()
        {
            Assert.AreEqual(2, _converted.Items.Count);
        }

        [TestMethod]
        public void Item()
        {
            var item = _converted.Items[0];
            Assert.AreEqual(
                "http://localhost:8080/restful/objects/org.incode.eurocommercial.contactapp.module.number.dom.ContactNumber/21",
                item.href);
            Assert.AreEqual(
                "+33 3 22 99 11 77 (Office)",
                item.title);
            Assert.AreEqual(
                "21",
                item.instanceId);
            
            Assert.AreEqual(
                "Office",
                item["type"]);
            
            Assert.AreEqual(
                "Benoît Fouré",
                item["owner"]["title"]);

        }
        [TestMethod]
        public void RO()
        {
            var ro = _converted.ro;
          
            Assert.IsNotNull(ro);
            
         }
        
        [TestMethod]
        public void RO_ResultType()
        {
            var ro = _converted.ro;
          
            Assert.IsNull(ro.resulttype);
         }
        
        [TestMethod]
        public void RO_Links()
        {
            var ro = _converted.ro;
          
            Assert.AreEqual(3,ro.links.Count);
        }
        
        [TestMethod]
        public void RO_Link()
        {
            var link = _converted.ro.links[0];

            Assert.AreEqual("self", link.rel);
            Assert.AreEqual("http://localhost:8080/restful/objects/org.incode.eurocommercial.contactapp.module.contacts.dom.Contact/14/collections/contactNumbers", link.href);
            Assert.AreEqual("GET", link.method);
            Assert.AreEqual("application/json;profile=\"urn:org.restfulobjects:repr-types/object-collection\"", link.type);
        }
        
        [TestMethod]
        public void RO_result()
        {
            var ro = _converted.ro;
          
            Assert.IsNull(ro.result);
        }

        [TestMethod]
        public void RO_value()
        {
            var ro = _converted.ro;
          
            Assert.IsNotNull(ro.value);
           Assert.AreEqual(2,ro.value.Count());
        }


        [TestMethod]
        public void RO_value_Items()
        {
            var value = _converted.ro.value;
          
            Assert.IsNotNull(value);
            Assert.AreEqual(2,value.Count());
        }
     
        [TestMethod]
        public void RO_value_item()
        {
            var link = _converted.ro.value.ElementAt(0);
          
            Assert.IsNotNull(link);
            
            Assert.AreEqual("urn:org.restfulobjects:rels/value", link.rel);
            Assert.AreEqual("http://localhost:8080/restful/objects/org.incode.eurocommercial.contactapp.module.number.dom.ContactNumber/21", link.href);
            Assert.AreEqual("GET", link.method);
            Assert.AreEqual("application/json;profile=\"urn:org.restfulobjects:repr-types/object\"", link.type);
            Assert.AreEqual("+33 3 22 99 11 77 (Office)", link.title);
        }
    }
    
    
}