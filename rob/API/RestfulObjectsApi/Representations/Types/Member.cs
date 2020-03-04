using Newtonsoft.Json;

public class Member : Resource<Link>
{
    public string id { get; set; }
    public string memberType { get; set; }
    public ILink details => FindByRel(roRel("details"));
    public MemberExtensions extensions { get; set; }
}

    public class MemberExtensions
    {
        [JsonProperty("x-isis-format")]
        public string format { get; set;}
    }
        
        
