using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rob.API.ApacheISISApi;
using rob.Layout;
using rob.Pages.ObjectViews;

namespace rob.representations.tests.unitTests
{
    [TestClass]
    public class CollectionViewTests : UnitTestBase
    {
        public class TestableCollectionView:LayoutCollectionView
        {
            public new void StateHasChanged()
            {
                
            }
            public void TestableOnParametersSet()
            {
                base.OnParametersSetAsync();
            }

            public void TestableRender()
            {
                var g = (ComponentBase) this;
                
            }
        }
        
        
        private IsisSingleObject _iso;
        private ObjectLayout _layout;
        private LayoutFieldSet _contactDetails;

        [TestInitialize]
        public void Setup()
        {
            _iso = LoadIsisSingleObject();
            var raw = System.IO.File.ReadAllText("data/layout.json");
            _layout = System.Text.Json.JsonSerializer.Deserialize<ObjectLayout>(raw);
            _contactDetails = _layout.row[1].cols[0].col.tabGroup[0].tab[0].row[0].cols[0].col.fieldSet[0];
        }


    }

    [TestClass]
    public class UnreferencedMembersTests : UnitTestBase
    {
        private IsisSingleObject _iso;
        private ObjectLayout _layout;
        private LayoutFieldSet _contactDetails;

        [TestInitialize]
        public void Setup()
        {
            _iso = LoadIsisSingleObject();
            var raw = System.IO.File.ReadAllText("data/layout.json");
            _layout = System.Text.Json.JsonSerializer.Deserialize<ObjectLayout>(raw);
            _contactDetails = _layout.row[1].cols[0].col.tabGroup[0].tab[0].row[0].cols[0].col.fieldSet[0];

        }

     
        [TestMethod]
        public void Actions()
        {
            var unreferenced = new UnrefencedMembersFilter(_iso,_layout);
            Assert.AreEqual(0,unreferenced.Actions.Count());
      
            _contactDetails.action = new LayoutAction[]{};
            unreferenced = new UnrefencedMembersFilter(_iso,_layout);
           
            Assert.AreEqual(3,unreferenced.Actions.Count());
        }
        
        [TestMethod]
        public void Properties()
        {
            var unreferenced = new UnrefencedMembersFilter(_iso,_layout);
          
            Assert.AreEqual(0,unreferenced.Properties.Count());
         
            _contactDetails.property = new LayoutProperty[]{};
            unreferenced = new UnrefencedMembersFilter(_iso,_layout);
            
            Assert.AreEqual(3,unreferenced.Properties.Count());
        }
    }
}