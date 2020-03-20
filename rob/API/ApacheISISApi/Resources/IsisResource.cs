using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace rob.API.ApacheISISApi.Resources
{

    /// <summary>
    /// ISIS Representation of a collection
    /// </summary>
    public class SimpleIsisCollection:IDisplayableObject
    {
        public IList<SimpleIsisItem> Items { get; set; }
        public IsisRo ro { get; set; }
        
        // Resource
        public IList<Link> links { get; set; } 
        public ILink Layout => FindByRel(isisRel("object-layout"));
        protected ILink FindByRel(string rel)
        {
            return links.Single(x => x.rel.Contains(rel));
        }
        protected string isisRel(string rel)
        {
            return $"urn:org.apache.isis.restfulobjects:rels/{rel}";
        }
    }

    /// <summary>
    /// Isis representation of an object
    /// </summary>
    public class SimpleIsisObject:SimpleIsisItem
    {
        public IsisRo ro { get; set; }
    }
    
    /// <summary>
    /// Isis representation of a list or collection item
    /// </summary>

    public class SimpleIsisItem
    {
        [JsonExtensionData]
        private IDictionary<string, JToken> UnmatchedProperties;
        
        [JsonProperty("$$href")]
        public string href { get; set; }
        [JsonProperty("$$title")]
        public string title { get; set; }
        [JsonProperty("$$instanceId")]
        public string instanceId { get; set; }

        public JToken this[string key] => UnmatchedProperties[key];
    }
    
    /// <summary>
    /// Details of an object/collection or action result
    /// </summary>
    public class IsisRo{
        // generalise to LinkSet
        public IList<Link> links { get; set; } 
        //class may be specific to LIst, coll or Object
        public IsisExtension extensions { get; set; }
        
        //specific to action results?
        [JsonProperty("resulttype")]
        public string resulttype { get; set; }
        public RoResult result { get; set; }
        
        //object...
        public string title { get; set; }
        private DomainType domainType { get; set; }
        public string instanceId { get; set; }
        public IDictionary<string, Member> members { get; set; }
        
        public IDictionary<string, Member> actions { get; set; }
        public IDictionary<string, Member> properties { get; set; }
        
        // collection
        public string id { get; set; }
        public string memberType { get; set; }
        public IEnumerable<ExtendedLink>  value { get; set; }
        
        // Resource
        public ILink Layout => FindByRel(isisRel("object-layout"));
        protected ILink FindByRel(string rel)
        {
            return links.Single(x => x.rel.Contains(rel));
        }
        protected string isisRel(string rel)
        {
            return $"urn:org.apache.isis.restfulobjects:rels/{rel}";
        }
    }
    
    /// <summary>
    /// The result of an action
    /// </summary>

    public class RoResult
    {
        public IList<ExtendedLink> value { get; set; }
        public IsisExtension extensions { get; set; }
    }

}