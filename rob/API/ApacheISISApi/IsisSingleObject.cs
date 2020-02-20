using System;
using Newtonsoft.Json.Linq;

namespace rob.API.ApacheISISApi
{
    public class IsisSingleObject:IDisplayableObject
    {
        public JObject Decorated { get; private set; }
        public IsisSingleObject(JObject decorated)
        {
            Decorated = decorated;
        }

        public JToken this[string propertyName]
        {
            get
            {
                return Decorated[propertyName];
            }
        }

        
    }
}
