using System;

namespace rob.layout.representations
{
    public class ObjectLayout
    {
        public LayoutRow[] row { get; set; }
    }

    public class LayoutRow
    {
        public LayoutColumnCollection[] cols { get; set; } 
    }

    public class LayoutColumnCollection
    {
        public LayoutColumn col { get; set; }
    }

    public class LayoutColumn
    {
        public LayoutTabGroup[] tabGroup { get; set; }
        public LayoutFieldSet[] fieldSet { get; set; }
    }

    public class LayoutTabGroup
    {
        public LayoutTab[] tab { get; set; }
    }

    public class LayoutTab
    {
        public string name { get; set; }
        public LayoutRow[] row { get; set; }
    }

    public class LayoutFieldSet
    {
        public string name { get; set; }
        public LayoutProperty[] property { get; set; } = new LayoutProperty[]{};
        public LayoutAction[] action { get; set; } = new LayoutAction[]{};
    }

    public class LayoutProperty
    {
        public string name { get; set; }
        public string id { get; set; }
    }
    public class LayoutAction
    {
        public string id { get; set; }
    }
}