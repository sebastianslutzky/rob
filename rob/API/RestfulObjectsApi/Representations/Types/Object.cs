using System.Text.Json.Serialization;

namespace RestfulObjectApi.Representation.Types
{
    public class IsisRestfulObject{
        [JsonPropertyName("$$href")]
        public string href {get;set;}

        [JsonPropertyName("company")]
        public string co {get;set;}
    }
    public class Object : AbstractObjectResourceList<Link, IsisExtension>
    {
        public string title { get; set; }
    }
    public class ObjectAction : AbstractObjectResourceList<Link, IsisExtension>
    {
        public string title { get; set; }
        public Link invoke => FindByRel("urn:org.restfulobjects:rels/invoke");
    }
}