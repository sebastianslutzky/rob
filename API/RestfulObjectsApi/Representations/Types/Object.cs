namespace RestfulObjectApi.Representation.Types
{
    public class Object : AbstractObjectResourceList<Link, IsisExtension>
    {
        public string title { get; set; }
    }
}