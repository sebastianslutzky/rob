namespace RestfulObjectApi.Representation.Types
{
    public class HomePage : Resource<Link>
    {
        public ILink User => FindByRel(roRel("user"));
        public ILink Version => FindByRel(roRel("version"));
        public ILink DomainTypes => FindByRel(roRel("domain-types"));
        public ILink DomainServices => FindByRel(roRel("services"));
    }
}