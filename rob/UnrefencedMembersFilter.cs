using System.Collections.Generic;
using System.Linq;
using rob.API.ApacheISISApi;
using rob.Layout;

namespace rob
{
    public class UnrefencedMembersFilter
    {
        public IEnumerable<Member> Properties { get; set; } = new Member[]{};
        public IEnumerable<Member> Actions { get; set; } = new Member[] { };

        public UnrefencedMembersFilter(IsisSingleObject iso, ObjectLayout layout)
        {
            var collector = new MembersCollectorVisitor();
            
            layout.Accept(collector);
            Actions = iso.ro.Actions.Except(collector.Actions, new MemberIdentityComparer()).OfType<Member>();

           Properties = iso.ro.Properties.Except(collector.Properties, new MemberIdentityComparer()).OfType<Member>();
        }
    }
}