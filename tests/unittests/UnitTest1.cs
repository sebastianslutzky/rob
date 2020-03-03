using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestfulObjectApi.Representation.Types;
using rob;

namespace unittests
{
  

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
        public void LoadHomePage()
        {
            Task<HomePage> homePage= api.LoadHomePage();
            homePage.Wait();
            var result = homePage.Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.DomainServices);
        }

        
        [TestMethod]
        public void LoadServices()
        {
            var homePage = GetHomePage();

            //act 
            Task<rob.Representation.Types.List> servicesTask = api.Load<rob.Representation.Types.List>(homePage.DomainServices);
            servicesTask.Wait();

            var services = servicesTask.Result;

            Assert.IsNotNull(services);
        }

        [TestMethod]
        public void LoadAService(){
            var svcs = GetServices();
            var contacts = svcs.value.Single(x=> x.title == "Contacts");

            var contactResource = api.Load<RestfulObjectApi.Representation.Types.ObjectContext>(contacts);
            contactResource.Wait();
            Assert.IsNotNull(contactResource.Result);
            Assert.AreEqual("PRIMARY",contactResource.Result.extensions.menuBar);
        }

        [TestMethod]
        public void LoadActionDescriptor(){
           RestfulObjectApi.Representation.Types.ObjectContext contactsMenu = ContactMenu();

            Task<ExpandoObject> p = api.Load<ExpandoObject>(contactsMenu.members["listAll"].details);
            p.Wait();
            Assert.IsNotNull(p.Result);
        }

        [TestMethod]
        public void InvokeGetActionNoParams(){
            var listAll = ListAllContacts();
            var raw = isisApi.Load(listAll.invoke,"");
            raw.Wait();
            Assert.IsNotNull(raw.Result);
            Assert.IsTrue(raw.Result.ResultObjects.Count() > 0);
        }

        [TestMethod]
        public void InvokeActionService(){
            var invoker = new ActionInvocationService(null,isisApi,null);

            var listAll = ListAllContacts();
            var raw = invoker.InvokeAction(listAll,"eapepe");
            Assert.IsNotNull(raw.Result);
            Assert.IsTrue(raw.Result.ResultObjects.Count() > 0);
        }

          [TestMethod]
        public void TestIsisObject(){
            var invoker = new ActionInvocationService(null,isisApi,null);
            var listAll = ListAllContacts();
            var result = invoker.InvokeAction(listAll,"eapepe");
            result.Wait();
            var list = result.Result;

            Assert.IsFalse(list.IsEmpty);
            Assert.IsTrue(list.Columns.Count > 0);
        }


        [TestMethod]
        public void IsisSingleObject(){
            var isisObj = LoadIsisObject();
            var name = isisObj["name"];
            Assert.AreEqual("Benoît Fouré", name);           
        }

        [TestMethod]
        public void SingleObjectTitle()
        {
            var isisObj = LoadIsisObject();
            var name = isisObj.Title;
            Assert.AreEqual("Benoît Fouré", name);
        }

    

        [TestMethod]
        public void SingleObjectRO() {

            var isisObj = LoadIsisObject();
            Assert.AreEqual(5, isisObj.Links.Length);
        }

     

        //integ test! (loads layout)
        [TestMethod]
        public void SingleObjectLoadLayout() {
            var layoutLink = LoadIsisObject().Layout;
            var layout =  api.Load<Object>(layoutLink);
            Assert.IsNotNull(layout);
        }


        private ObjectAction ListAllContacts() {
            var menu = ContactMenu();
            Task<ObjectAction> p = api.Load<ObjectAction>(
                menu.members["listAll"].details);
            p.Wait();
            return p.Result; 
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
    }
}
