using System.Collections.Generic;
using System.Linq;
using rob.API.ApacheISISApi;
using rob.Layout;

namespace rob
{
    public class CollectionLayoutFilter
    {
        private IsisSingleObject _iso;
        private LayoutCollection _layout;
        public Member Collection { get; }
        public IEnumerable<Member> Actions { get; private set; } 
        public CollectionLayoutFilter(IsisSingleObject iso,LayoutCollection layout)
        {
            _iso = iso;
            _layout = layout;

            Actions = from action in iso.ro.Actions
                join layoutAction in _layout.action on action.id equals  layoutAction.id
                select action;

            Collection = iso.ro.collection.FirstOrDefault(x => x.id == _layout.id);
        }
    }
}