using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace rob.API.ApacheISISApi.Representations
{
    public class ISORO:Resource<Link>
    {
        [JsonIgnore]
        public IDictionary<string,Member> members { get; set; }

        public IEnumerable<Member> Actions
        {
            get {  return members.Values.Where(m => m.memberType == "action"); }
        }
        public IEnumerable<Member> Properties
        {
            get { return members.Values.Where(m => m.memberType == "property"); }
        }
        
        public IEnumerable<Member> collection
        {
            get { return members.Values.Where(m => m.memberType == "collection"); }
        }

        
        public ILink Layout => FindByRel(isisRel("object-layout"));
    }
}