using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace rob.API.ApacheISISApi
{
    public class JTokenWrapperLink : ILink
    {
        private JToken _wrapped;
        public JTokenWrapperLink(JToken wrapped)
        {
            _wrapped = wrapped;

        }
        public string rel => _wrapped["rel"].Value<string>();

        public string href => _wrapped["href"].Value<string>();

        public string method => _wrapped["method"].Value<string>();

        public string type => _wrapped["type"].Value<string>();

        public string title => _wrapped["title"].Value<string>();
    }

    public class IsisSingleObject:Resource<JTokenWrapperLink>, IDisplayableObject
    {
        public JObject Decorated { get; private set; }

        public IsisSingleObject(JObject decorated)
        {
            Decorated = decorated;
            var ro = this["$$ro"];
            var links = ro["links"] as JArray;
            Links = links.Select(x => new JTokenWrapperLink(x)).ToArray();
        }

        public JToken this[string propertyName]
        {
            get
            {
                return Decorated[propertyName];
            }
        }

        #region Extracted Fields
        public JToken Title => this["$$title"];

        public ILink Layout => FindByRel(isisRel("object-layout"));
        #endregion


    }
}
