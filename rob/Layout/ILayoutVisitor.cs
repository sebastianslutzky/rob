namespace rob.Layout
{
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
}