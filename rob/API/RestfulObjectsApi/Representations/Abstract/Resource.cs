﻿using System;
using System.Linq;

public abstract class Resource<T> where T:ILink
{
    public T[] Links { get; set; }

    protected T FindByRel(string rel)
    {
        return Links.Single(x => x.rel.Contains(rel));
    }


    protected string roRel(string rel)
    {
        return $"urn:org.restfulobjects:rels/{rel}";
    }

    protected string isisRel(string rel)
    {
        return $"urn:org.apache.isis.restfulobjects:rels/{rel}";
    }
}
