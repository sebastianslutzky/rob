public abstract class AbstractResourceList<T, V> : Resource<Link> where T : Link where V : class
{
    public ILink Self => FindByRel("self");

  

    public V extensions { get; set; }
}
