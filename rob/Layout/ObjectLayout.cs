using System;

namespace rob.Layout
{
    //public class LayoutVisitorIterator:IEn
    public interface ILayoutVisitor
    {
        void Visit(ObjectLayout action);
        void Visit(LayoutAction action);
        void Visit(LayoutProperty prop);
        void Visit(LayoutRow row);
        void Visit(LayoutColumn column);
        void Visit(LayoutCollection column);
        void Visit(LayoutColumnCollection column);
        void Visit(LayoutTabGroup tabGroup);
        void Visit(LayoutFieldSet fieldSet);
        void Visit(LayoutTab tab);
    }

    public interface ILayoutElement
    {
        void Accept(ILayoutVisitor visitor);
    }
    
    public class ObjectLayout:ILayoutElement
    {
        public LayoutRow[] row { get; set; }
        public void Accept(ILayoutVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class LayoutRow:ILayoutElement
    {
        public LayoutColumnCollection[] cols { get; set; }
        public void Accept(ILayoutVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class LayoutColumnCollection:ILayoutElement
    {
        public LayoutColumn col { get; set; }
        public void Accept(ILayoutVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class LayoutColumn:ILayoutElement
    {
        public LayoutTabGroup[] tabGroup { get; set; } = new LayoutTabGroup[]{};
        public LayoutFieldSet[] fieldSet { get; set; } = new LayoutFieldSet[]{};
        public LayoutCollection[] collection { get; set; } = new LayoutCollection[]{};
        public void Accept(ILayoutVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public interface ActionsOwner
    {
        LayoutAction[] action { get; set; }
    }

    public class LayoutCollection:ILayoutElement
    {
        public LayoutAction[] action { get; set; }
        public void Accept(ILayoutVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class LayoutTabGroup:ILayoutElement
    {
        public LayoutTab[] tab { get; set; }
        public void Accept(ILayoutVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class LayoutTab:ILayoutElement
    {
        public string name { get; set; }
        public LayoutRow[] row { get; set; }
        public void Accept(ILayoutVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class LayoutFieldSet:ILayoutElement
    {
        public string name { get; set; }
        public bool? unreferencedActions { get; set; }
        public bool? unreferencedProperties { get; set; }
        public LayoutProperty[] property { get; set; } = new LayoutProperty[]{};
        public LayoutAction[] action { get; set; } = new LayoutAction[]{};
        public void Accept(ILayoutVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class LayoutProperty:IMemberIdentity,ILayoutElement
    {
        public string name { get; set; }
        public string id { get; set; }
        public void Accept(ILayoutVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class LayoutAction:IMemberIdentity,ILayoutElement
    {
        public string id { get; set; }
        public void Accept(ILayoutVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}