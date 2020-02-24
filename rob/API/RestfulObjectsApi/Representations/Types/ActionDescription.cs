namespace RestfulObjectApi.Representation.Types
{
    public class ActionDescription : Resource<Link>
    {
        public string id { get; set; }
        public System.Object parameters { get; set; }

        public ILink Self => FindByRel("self");

        public DomainTypeExtension extensions { get; set; }
    }
}