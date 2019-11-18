namespace RestfulObjectApi.Representation.Types
{
    public class ActionDescription : Resource
    {
        public string id { get; set; }
        public System.Object parameters { get; set; }

        public Link Self => FindByRel("self");

        public DomainTypeExtension extensions { get; set; }
    }
}