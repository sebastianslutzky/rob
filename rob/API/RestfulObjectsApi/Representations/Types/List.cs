namespace rob.Representation.Types
{
    public class List : AbstractObjectResourceList<Link, DomainTypeExtension>
    {
        public Link[] value { get; set; }
    }
}