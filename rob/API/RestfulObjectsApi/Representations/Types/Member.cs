public class Member : Resource<Link>
{
    public string id { get; set; }
    public string memberType { get; set; }
    public ILink details => FindByRel(roRel("details"));
}
