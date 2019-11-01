namespace RestfulObjectApi.Representation.Types
{
    public class ActionDescription : DomainType
    {
        public string id { get; set; }
        public Link[] parameters { get; set; }
    }
}