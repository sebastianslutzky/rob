using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestfulObjectApi.Representation.Types;

namespace rob.representations.tests.unitTests
{

    [TestClass]
    public class IntegTests:UnitTestBase
    {
        
    

        private Api api;
        private ApacheIsisApi isisApi;

        [TestInitialize]
        public void Setup(){
            api = new Api(new System.Net.Http.HttpClient(),null);
            isisApi = new ApacheIsisApi(new System.Net.Http.HttpClient(),null);
        }
        
    }

    [TestClass]
    public class UnitTest1:UnitTestBase
    {
    
        /// <summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
     
        private Api api;
        private ApacheIsisApi isisApi;

        [TestInitialize]
        public void Setup(){
            api = new Api(new System.Net.Http.HttpClient(),null);
            isisApi = new ApacheIsisApi(new System.Net.Http.HttpClient(),null);
        }

    
        [TestMethod]
        public void IsisSingleObject(){
            var isisObj = LoadIsisSingleObject();
            var name = isisObj["name"];
            Assert.AreEqual<JToken>("Benoît Fouré", name);           
        }

        [TestMethod]
        public void SingleObjectTitle()
        {
            var isisObj = LoadIsisSingleObject();
            var name = isisObj.Title;
            Assert.AreEqual<JToken>("Benoît Fouré", name);
        }

    

        [TestMethod]
        public void SingleObjectRO() {

            var isisObj = LoadIsisSingleObject();
            Assert.AreEqual<int>(5, isisObj.ro.links.Length);
        }

     

        //integ test! (loads layout)
        [TestMethod]
        public void SingleObjectLoadLayout() {
            var layoutLink = LoadIsisSingleObject().Layout;
            var layout =  api.Load<Object>(layoutLink);
            Assert.IsNotNull(layout);
        }

        private RestfulObjectApi.Representation.Types.ObjectContext ContactMenu() {
            var svcs = GetServices();
            var contacts = svcs.value.Single(x=> x.title == "Contacts");
            var contactResource = api.Load<RestfulObjectApi.Representation.Types.ObjectContext>(contacts);
            contactResource.Wait();
            return contactResource.Result;
        }

        private rob.Representation.Types.List GetServices(){
            Task<rob.Representation.Types.List> task = api.Load<rob.Representation.Types.List>(GetHomePage().DomainServices);
            task.Wait();
            return task.Result;
        }

        private HomePage GetHomePage(){
             //move to setup
            Task<HomePage> homePageTask = api.LoadHomePage();
            homePageTask.Wait();
            return homePageTask.Result;
        }
        
        private ObjectActionInstance ListAllContacts() {
            var menu = ContactMenu();
            Task<ObjectActionInstance> p = api.Load<ObjectActionInstance>(
                menu.members["listAll"].details);
            p.Wait();
            return p.Result; 
        }
    }
}
