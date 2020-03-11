using System;
using System.Collections.Generic;
using rob.Layout;

namespace rob
{
    public class MembersCollectorVisitor:ILayoutVisitor
    {
        public IList<LayoutAction> Actions = new List<LayoutAction>();
        
        public IList<LayoutProperty> Properties = new List<LayoutProperty>();
        
        public void Visit(ObjectLayout obj)
        {
            Array.ForEach(obj.row, x => x.Accept(this));
        }

        public void Visit(LayoutAction action)
        {
            Actions.Add(action);
        }

        public void Visit(LayoutProperty prop)
        {
            Properties.Add(prop);
        }

        public void Visit(LayoutRow row)
        {
            Array.ForEach(row.cols,c => c.col.Accept(this));
        }

        public void Visit(LayoutColumn column)
        {
            Array.ForEach(column.collection,c=>c.Accept(this));
            Array.ForEach(column.fieldSet,f=>f.Accept(this));
            Array.ForEach(column.tabGroup,tg=>tg.Accept(this));
        }

        public void Visit(LayoutCollection column)
        {
            Array.ForEach(column.action,x=>x.Accept(this));
        }

        public void Visit(LayoutColumnCollection column)
        {
            column.col.Accept(this);
        }

        public void Visit(LayoutTabGroup tabGroup)
        {
            Array.ForEach(tabGroup.tab, t=>t.Accept(this));
        }

        public void Visit(LayoutFieldSet fieldSet)
        {
            Array.ForEach(fieldSet.action, a =>a.Accept(this));
            Array.ForEach(fieldSet.property, p =>p.Accept(this));
        }

        public void Visit(LayoutTab tab)
        {
            Array.ForEach(tab.row, r=>r.Accept(this));
        }
    }
}