using System.Text.Json.Serialization;

namespace RestfulObjectApi.Representation.Types
{
    public class IsisRestfulObject{
        [JsonPropertyName("$$href")]
        public string href {get;set;}

        [JsonPropertyName("company")]
        public string co {get;set;}
    }
    public class ObjectContext : AbstractObjectResourceList<Link, IsisExtension>
    {
        public string title { get; set; }
    }

    public class ObjectActionInstance : ObjectMemberInstance
    {
        public ILink invoke => FindByRel("urn:org.restfulobjects:rels/invoke");
    }
    public class ObjectMemberInstance : AbstractObjectResourceList<Link, IsisExtension>
    {
        public string title { get; set; }
    }
    
}



