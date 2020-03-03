using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using rob.API.ApacheISISApi.Representations;

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
            
            //RO
            var localRo = this["$$ro"];
            ro = localRo.ToObject<ISORO>();
            var rawMembers = localRo["members"];
            var membersAsHashTable = rawMembers.ToObject<Dictionary<string,Member>>();
            ro.members = membersAsHashTable;
        }

        public JToken this[string propertyName]
        {
            get
            {
                return Decorated[propertyName];
            }
        }
        
        public ISORO ro { get; private set; }

        #region Extracted Fields
        public JToken Title => this["$$title"];


        public ILink Layout => ro.Layout;

        #endregion


    }
}
