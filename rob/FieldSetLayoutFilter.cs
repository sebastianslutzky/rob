using System;
using System.Collections.Generic;
using System.Linq;
using RestfulObjectApi.Representation.Types;
using rob.API.ApacheISISApi;
using rob.layout.representations;
using rob.Shared;

namespace rob
{
    public class FieldSetLayoutFilter
    {
        private IsisSingleObject _iso;
        private LayoutFieldSet _layout;
        public IEnumerable<Member> Properties { get; private set; } 
        public IEnumerable<Member> Actions { get; private set; } 
        public FieldSetLayoutFilter(IsisSingleObject iso,LayoutFieldSet layout)
        {
            _iso = iso;
            _layout = layout;

            Actions = from action in iso.ro.Actions
                join layoutAction in _layout.action on action.id equals  layoutAction.id
                select action;

            Properties = from prop in iso.ro.Properties
                join layoutProp in _layout.property on prop.id equals  layoutProp.id
                select prop;
        }
        
    }
}