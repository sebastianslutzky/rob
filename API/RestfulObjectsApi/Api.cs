
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using static rob.Pages.FetchData;
using Blazor.Extensions.Logging;
using System.Dynamic;
using System.Net.Http.Headers;
using System;
using System.Linq;

public class Api{
    private HttpClient http;
    private ILogger<Api> logger;
    public Api(HttpClient http,ILogger<Api> logger)
    {
       this.http = http; 
       this.logger = logger; 
    }
     public async Task<HomePage> LoadHomePage(){
        var restfulBaseAddress = "http://localhost:8080";
        var restfulApiAddress = $"{restfulBaseAddress}/restful/";
        var homePage = restfulApiAddress;

        var link = new Link{href = restfulApiAddress};
        return await this.Load<HomePage>(link);
     }

     public async Task<T> Load<T>(Link l) where T:class {
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
        "Basic", Convert.ToBase64String(
            System.Text.ASCIIEncoding.ASCII.GetBytes(
               $"superadmin:pass")));
         //this.logger.LogInformation("Loading " + l.href);
         var obj  = await http.GetJsonAsync<T>(l.href);
         //logger.LogInformation<T>(obj);
         return obj;
     }
}


public class Resource{
    public Link[] links{ get;set;}

    protected Link FindByRel(string rel){
        return links.Single(x=> x.rel == rel);
    }

    protected string roRel(string rel){
       return $"urn:org.restfulobjects:rels/{rel}";
    }
}

public class HomePage:Resource{
    public Link  User => FindByRel(roRel("user"));
    public Link  Version => FindByRel(roRel("version"));
    public Link  DomainTypes => FindByRel(roRel("domain-types"));
    public Link  DomainServices => FindByRel(roRel("services"));
}

public class User:Resource{
    public string userName{get;set;}
    public string[] roles{get;set;}
}

public class AbstractResourceList<T,V>:Resource where T:Link where V:class{
    public Link Self => FindByRel("self");

    public T[] value {get;set;}

    public V extensions {get;set;}
}

public class ResourceList:AbstractResourceList<Link,Object>{
}

public class Link{
     public string rel{get;set;}
     public string href{get;set;}
     public string method{get;set;}
     public string type{get;set;}
}