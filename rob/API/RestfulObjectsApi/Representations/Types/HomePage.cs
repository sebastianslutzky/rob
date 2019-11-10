namespace RestfulObjectApi.Representation.Types
{
    public class HomePage : Resource
    {
        public Link User => FindByRel(roRel("user"));
        public Link Version => FindByRel(roRel("version"));
        public Link DomainTypes => FindByRel(roRel("domain-types"));
        public Link DomainServices => FindByRel(roRel("services"));
    }
}