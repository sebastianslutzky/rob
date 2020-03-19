using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using rob.API.ApacheISISApi.Resources;

namespace rob.API.ApacheISISApi
{
    public class IsisResourceConverter : JsonConverter<SimpleIsisCollection>
    {
        public override void WriteJson(JsonWriter writer, SimpleIsisCollection value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override SimpleIsisCollection ReadJson(JsonReader reader, Type objectType, SimpleIsisCollection existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            //list result
            var jobject = JArray.Load(reader);
            existingValue =  new SimpleIsisCollection() { Items = new List<SimpleIsisItem>()};
            foreach (var item in jobject)
            {
                if (item["$$ro"] == null)
                {
                    existingValue.Items.Add(item.ToObject<SimpleIsisItem>());
                }
                else
                {
                    var ro = item["$$ro"];
                    existingValue.ro = ro.ToObject<IsisRo>();
                }
            }

            return existingValue;
        } 
    }
}