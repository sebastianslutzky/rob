using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Blazor.Extensions.Logging;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

public class ApacheIsisApi{
    private HttpClient http;
    private ILogger<ApacheIsisApi> logger;
    public ApacheIsisApi(HttpClient http,ILogger<ApacheIsisApi> logger)
    {
       this.http = http; 
       this.logger = logger; 
    }
     public async Task<T> Load<T>(Link l) where T:class {
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
        "Basic", Convert.ToBase64String(
            System.Text.ASCIIEncoding.ASCII.GetBytes(
               $"superadmin:pass")));
        http.DefaultRequestHeaders.TryAddWithoutValidation("Accept","application/json;profile=\"urn:org.apache.isis/v1\"");
        // ,"profile='urn:org.apache.isis/v1'"});
        // this.logger.LogInformation("Loading " + l.href);
         var obj  = await http.GetJsonAsync<T>(l.href);
         //logger.LogInformation<T>(obj);
         return obj;
     }
}
     public class ExtendedLink:Link{
         public string title{get;set;}
     }

public class IsisExtension{
    public bool isPersistent{get;set;}
    public bool isService {get;set;}
    public string menuBar {get;set;}
    public string oid {get;set;}
}
public class ExtendedResourceList:AbstractObjectResourceList<ExtendedLink,IsisExtension>{
     public string title{get;set;}
}