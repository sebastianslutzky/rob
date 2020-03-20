using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rob.API.ApacheISISApi;
using rob.Layout;

namespace rob.representations.tests.unitTests
{


    [TestClass]
    public class CollectionLayoutFilterTests : UnitTestBase
    {
        private IsisSingleObject _iso;
        private ObjectLayout _layout;
        private LayoutCollection _collLayout;

        [TestInitialize]
        public void Setup()
        {
            _iso = LoadIsisSingleObject();
            _layout = GetLayout();
            _collLayout = _layout.row[1].cols[1].col.tabGroup[0].tab[0].row[0].cols[0].col.collection[0];
            Assert.AreEqual("contactNumbers",_collLayout.id);
        }
        
        
        [TestMethod]
        public void CollectionMemberIsExtracted()
        {
            var filter = new CollectionLayoutFilter(_iso,_collLayout);

            Assert.IsNotNull(filter.Collection);
            Assert.AreEqual("contactNumbers",filter.Collection.id);
        }
        
        [TestMethod]
        public void CollectionActions()
        {
            var filter = new CollectionLayoutFilter(_iso,_collLayout);

            Assert.IsNotNull(filter.Actions);
            Assert.AreEqual(2,filter.Actions.Count());
        }
        
        
    }

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
            Assert.AreEqual("company",Enumerable.ElementAt<KeyValuePair<string, Member>>(iso.ro.members, 0).Value.id);
        }
        
        [TestMethod]
        public void ro_actions()
        {
            var iso = LoadIsisSingleObject();
            var actions = iso.ro.Actions;
            
            Assert.AreEqual(8,Enumerable.Count<Member>(actions));
        }
        [TestMethod]
        public void ro_properties()
        {
            var iso = LoadIsisSingleObject();
            var props = iso.ro.Properties;
            
            Assert.AreEqual(6,Enumerable.Count<Member>(props));
        }
        
        [TestMethod]
        public void ro_members()
        {
            var iso = LoadIsisSingleObject();
            Assert.IsNotNull(iso.ro.members);
            Assert.AreEqual<int>(16,iso.ro.members.Count);
        }
        [TestMethod]
        public void ro_links()
        {
            var iso = LoadIsisSingleObject();
            Assert.IsNotNull(iso.ro.links);
            Assert.AreEqual<int>(5,iso.ro.links.Length);
        }
        [TestMethod]
        public void ro_collection()
        {
            var iso = LoadIsisSingleObject();
            Assert.IsNotNull(iso.ro.collection);
            Assert.AreEqual(2,Enumerable.Count<Member>(iso.ro.collection));
        }
    }
}