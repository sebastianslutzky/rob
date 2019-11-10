namespace RestfulObjectApi.Representation.Types
{
    public class User : Resource
    {
        public string userName { get; set; }
        public string[] roles { get; set; }
    }
}