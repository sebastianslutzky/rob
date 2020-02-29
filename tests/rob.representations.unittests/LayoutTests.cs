using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using rob.layout.representations;

namespace unittests.representations
{
    public class UnitTestBase
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        
    }
    
    [TestClass]
    public class LayoutTests : UnitTestBase
    {
      
        [TestMethod]
        public void ObjectLayout_Rows()
        {
            var raw = System.IO.File.ReadAllText("data/layout.json");
            var layout = System.Text.Json.JsonSerializer.Deserialize<ObjectLayout>(raw);
            Assert.IsNotNull(layout.row);
            Assert.AreEqual(2, layout.row.Length);
        }
        
        
        [TestMethod]
        public void RowLayout_Columns()
        {
            var raw = System.IO.File.ReadAllText("data/layout.json");
            var layout = System.Text.Json.JsonSerializer.Deserialize<ObjectLayout>(raw);
            var columns =  layout.row[1].cols;
            Assert.IsNotNull(columns);
            Assert.AreEqual(3, columns.Length);
        }
        
        [TestMethod]
        public void Columns_col()
        {
            var raw = System.IO.File.ReadAllText("data/layout.json");
            var layout = System.Text.Json.JsonSerializer.Deserialize<ObjectLayout>(raw);
            foreach (var row in layout.row)
            {
                foreach (var cols in row.cols)
                {
                    Assert.IsNotNull(cols.col);
                }
            }
        }
        
         [TestMethod]
         public void ColumnLayout_tabGroup()
         {
             var raw = System.IO.File.ReadAllText("data/layout.json");
             var layout = System.Text.Json.JsonSerializer.Deserialize<ObjectLayout>(raw);
             var tabGroup =  layout.row[1].cols[0].col.tabGroup;
             Assert.IsNotNull(tabGroup);
             Assert.AreEqual(1, tabGroup.Length);
         }
         
         [TestMethod]
         public void TabGroup_Tab()
         {
             var raw = System.IO.File.ReadAllText("data/layout.json");
             var layout = System.Text.Json.JsonSerializer.Deserialize<ObjectLayout>(raw);
             var tab =  layout.row[1].cols[0].col.tabGroup[0].tab;
             Assert.IsNotNull(tab);
             Assert.AreEqual(4, tab.Length);
         }
         [TestMethod]
         public void Tab_Row()
         {
             var raw = System.IO.File.ReadAllText("data/layout.json");
             var layout = System.Text.Json.JsonSerializer.Deserialize<ObjectLayout>(raw);
             var row =  layout.row[1].cols[0].col.tabGroup[0].tab[0].row;
             Assert.IsNotNull(row);
             Assert.AreEqual(1, row.Length);
         }
    }
}