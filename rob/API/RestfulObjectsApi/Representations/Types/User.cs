namespace RestfulObjectApi.Representation.Types
{
    public class User : Resource<Link>
    {
        public string userName { get; set; }
        public string[] roles { get; set; }
    }
}