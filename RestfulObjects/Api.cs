
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
     public async Task<Resource> LoadHomePage(){
        var restfulBaseAddress = "http://localhost:8080";
        var restfulApiAddress = $"{restfulBaseAddress}/restful/";
        var homePage = restfulApiAddress;


         http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
        "Basic", Convert.ToBase64String(
            System.Text.ASCIIEncoding.ASCII.GetBytes(
               $"superadmin:pass")));
         var obj  = await http.GetJsonAsync<HomePage>(restfulApiAddress);
         logger.LogInformation(obj);
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
    public Link Self => FindByRel("self");
    public Link  User => FindByRel(roRel("user"));
    public Link  Version => FindByRel(roRel("version"));
    public Link  DomainTypes => FindByRel(roRel("domain-types"));
    public Link  DomainServices => FindByRel(roRel("services"));
}


public class Link{
     public string rel{get;set;}
     public string href{get;set;}
     public string method{get;set;}
     public string type{get;set;}
}