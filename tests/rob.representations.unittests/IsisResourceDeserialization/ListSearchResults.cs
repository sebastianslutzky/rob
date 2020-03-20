using System.IO;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using rob.API.ApacheISISApi;
using rob.API.ApacheISISApi.Resources;

namespace rob.representations.unittests.IsisResourceDeserialization
{
    [TestClass]
    public class ListSearchResults
    {
        private SimpleIsisCollection _converted;

        [TestInitialize]
        public void Setup()
        {
            var raw = File.ReadAllText("data/list.json");
            _converted = JsonConvert.DeserializeObject<SimpleIsisCollection>(raw, new IsisResourceConverter());
        }

        [TestMethod]
        public void Items()
        {
            Assert.AreEqual(4, _converted.Items.Count);
        }

        [TestMethod]
        public void Item()
        {
            var item = _converted.Items[0];
            Assert.AreEqual(
                "http://localhost:8080/restful/objects/org.incode.eurocommercial.contactapp.module.contacts.dom.Contact/2",
                item.href);
            Assert.AreEqual(
                "Sebastian Slutzky",
                item.title);
            Assert.AreEqual(
                "2",
                item.instanceId);
            
            Assert.AreEqual(
                "Mr",
                item["company"]);

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
          
            Assert.AreEqual("list",ro.resulttype);
         }
        
        [TestMethod]
        public void RO_Links()
        {
            var ro = _converted.ro;
          
            Assert.AreEqual(2,ro.links.Count);
        }
        
        [TestMethod]
        public void RO_Link()
        {
            var link = _converted.ro.links[0];

            Assert.AreEqual("self", link.rel);
            Assert.AreEqual("http://localhost:8080/restful/services/org.incode.eurocommercial.contactapp.module.contacts.dom.ContactMenu/actions/listAll/invoke", link.href);
            Assert.AreEqual("GET", link.method);
            Assert.AreEqual("application/json;profile=\"urn:org.restfulobjects:repr-types/action-result\"", link.type);
        }
        
        [TestMethod]
        public void RO_result()
        {
            var ro = _converted.ro;
          
            Assert.IsNotNull(ro.result);
        }
        
        [TestMethod]
        public void RO_result_value()
        {
            var ro = _converted.ro;
          
            Assert.IsNotNull(ro.result.value);
        }
        
        [TestMethod]
        public void RO_result_value_links()
        {
            var value = _converted.ro.result.value;
          
            Assert.IsNotNull(value);
            Assert.AreEqual(4,value.Count);
        }
     
        [TestMethod]
        public void RO_result_value_link()
        {
            var link = _converted.ro.result.value[0];
          
            Assert.IsNotNull(link);
            
            Assert.AreEqual("urn:org.restfulobjects:rels/element", link.rel);
            Assert.AreEqual("http://localhost:8080/restful/objects/org.incode.eurocommercial.contactapp.module.contacts.dom.Contact/2", link.href);
            Assert.AreEqual("GET", link.method);
            Assert.AreEqual("application/json;profile=\"urn:org.restfulobjects:repr-types/object\"", link.type);
            Assert.AreEqual("Sebastian Slutzky", link.title);
        }
    }
    
    
}