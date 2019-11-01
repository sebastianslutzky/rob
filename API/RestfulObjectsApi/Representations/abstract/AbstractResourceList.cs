public abstract class AbstractResourceList<T, V> : Resource where T : Link where V : class
{
    public Link Self => FindByRel("self");

    public T[] value { get; set; }

    public V extensions { get; set; }
}
