using Microsoft.VisualStudio.TestTools.UnitTesting;
using rob.API.ApacheISISApi.Representations.layout;

namespace unittests
{
    [TestClass]
    public class LayoutTests : UnitTestBase
    {
        [TestMethod]
        public void SingleObjectLayoutLink()
        {
            var isisObj = LoadIsisObject();
            var layoutLink = isisObj.Layout;

            Assert.IsNotNull(layoutLink);
        }

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
            var row = layout.row[1];
            var columns = row.cols;
            Assert.IsNotNull(columns);
            Assert.AreEqual(3, columns.Length);
        }
        
    }
}