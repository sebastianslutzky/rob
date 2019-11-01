public class Member : Resource
{
    public string id { get; set; }
    public string memberType { get; set; }
    public Link details => FindByRel(roRel("details"));
}
