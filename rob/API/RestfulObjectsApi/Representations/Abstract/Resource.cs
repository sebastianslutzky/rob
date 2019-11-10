using System;
using System.Linq;

public abstract class Resource
{
    public Link[] links { get; set; }

    protected Link FindByRel(string rel)
    {
        return links.Single(x => x.rel.Contains(rel));
    }

    protected string roRel(string rel)
    {
        return $"urn:org.restfulobjects:rels/{rel}";
    }
}
