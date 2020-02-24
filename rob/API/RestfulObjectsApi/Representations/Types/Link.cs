public class Link:ILink
{
    public string rel { get; set; }
    public string href { get; set; }
    public string method { get; set; }
    public string type { get; set; }
    public string title { get; set; }
}

public interface  ILink
{
     string rel { get; }
     string href { get; }
     string method { get; }
     string type { get; }
     string title { get; }
}
