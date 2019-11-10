using System;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using System.Net.Http;

/// Takes care of calling an action with the right parameters, verb and headers (api)
public class ActionInvocationService{
    private Api api;

    private ILogger<ActionInvocationService> logger;

    public ActionInvocationService(Api api, ILogger<ActionInvocationService> logger)
    {
       this.api = api; 
       this.logger = logger; 
    }

    public async void InvokeAction(Member action){
       //todo: construct and pass Request object to API
       //construct: convert Member to request
       //  (extract link as target)
       var response = await api.Load<Object>(action.details);
       logger.LogInformation("-- here is the invocation details");
       logger.LogInformation(response);
       var request = new Request(action);
       
        this.api.Request(request);
       // If needs parameters, send out an event or use a ParameterCollector service
       // Once parameters are collected, send ParameterCollection and descriptor to API.
    }

}

public class Request{
   public Link Target{private set; get;}

   private HttpMethod method;
   public Request(Member action)
    {
        this.Target = action.details;
    }
}