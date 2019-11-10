using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestfulObjectApi.Representation.Types;
using rob;

namespace unittests
{
    [TestClass]
    public class UnitTest1
    {
        private Api api;

        [TestInitialize]
        public void Setup(){
            api = new Api(new System.Net.Http.HttpClient(),null);
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

            var contactResource = api.Load<RestfulObjectApi.Representation.Types.Object>(contacts);
            contactResource.Wait();
            Assert.IsNotNull(contactResource.Result);
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
