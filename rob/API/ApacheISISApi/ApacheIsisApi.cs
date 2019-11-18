using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Blazor.Extensions.Logging;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Linq;
using Newtonsoft.Json.Linq;

public class ApacheIsisApi{
    private HttpClient http;
    private ILogger<ApacheIsisApi> logger;
    public ApacheIsisApi(HttpClient http,ILogger<ApacheIsisApi> logger)
    {
       this.http = http; 
       this.logger = logger; 
    }
     public async Task<IsisObject> Load(Link l,string title) {
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
        "Basic", Convert.ToBase64String(
            System.Text.ASCIIEncoding.ASCII.GetBytes(
               $"superadmin:pass")));

        http.DefaultRequestHeaders.TryAddWithoutValidation("Accept","application/json;profile=\"urn:org.apache.isis/v1\"");
         var raw  = await http.GetStringAsync(l.href);
         JArray jsonVal = JArray.Parse(raw) as JArray;
         //todo: parse application/json; profile="urn:org.apache.isis/v1"; repr-type="list"
         // and select type based on repr-type
         return new IsisObject(jsonVal,title);
     }
}

public class IsisObject {
    private IEnumerable<dynamic> _rawObject;
    public IList<JToken> ResultObjects{get;private set;}

    public string Title{get;private set;}
    public IList<string> Columns {get; private set;}


    public bool IsEmpty => ResultObjects.Count == 0;

    public IsisObject(IEnumerable<dynamic> objects,string title)
    {
        Title = title;
        _rawObject = objects;
        ResultObjects = objects.OfType<JToken>()
        .Where( x => x["$$ro"] == null).ToList() ;
        Columns = ExtractColumns();
    }

    public IList<string> ExtractColumns(){
        if(IsEmpty){
            return new string[]{};
        }
        var sampleRow = ResultObjects[0];
        var asJobj = sampleRow as JObject;
        return asJobj.Properties()
            .Select(x=>x.Name)
            .Where(x => !x.StartsWith("$$"))
            .ToList();
    }
}
