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
using rob.API.ApacheISISApi;

public class ApacheIsisApi{
    private HttpClient http;
    private ILogger<ApacheIsisApi> logger;
    public ApacheIsisApi(HttpClient http,ILogger<ApacheIsisApi> logger)
    {
       this.http = http; 
       this.logger = logger; 
    }
     public async Task<IsisObject> Load(Link l,string title) {
        var token = JArray.Parse(await LoadRaw(l));
        return new IsisObject(token,title);
    }

    public async Task<IsisSingleObject> LoadAsIsisSingleObject(Link l) {
        var token = JObject.Parse(await LoadRaw(l));
        return new IsisSingleObject(token);
    }

    private async Task<string> LoadRaw(Link l) 
    {
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
      "Basic", Convert.ToBase64String(
          System.Text.Encoding.ASCII.GetBytes(
             $"superadmin:pass")));

        http.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json;profile=\"urn:org.apache.isis/v1\"");
        return await http.GetStringAsync(l.href);
        //todo: parse application/json; profile="urn:org.apache.isis/v1"; repr-type="list"
        // and select type based on repr-type
    }
}
