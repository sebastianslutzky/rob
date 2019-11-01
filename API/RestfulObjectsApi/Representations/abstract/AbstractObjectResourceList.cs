
using System.Collections.Generic;

public abstract class AbstractObjectResourceList<T, V> : AbstractResourceList<T, V> where T : Link where V : class
{
    public Dictionary<string, Member> members { get; set; }

    public Link DescribedBy => FindByRel("describedby");
    public bool HasMembers => members?.Count > 0;
}
