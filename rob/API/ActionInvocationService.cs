using System;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using RestfulObjectApi.Representation.Types;

/// Takes care of calling an action with the right parameters, verb and headers (api)
public class ActionInvocationService{
    public event EventHandler<ActionInvokedEventArgs> ActionInvoked;
    private Api api;
    private ApacheIsisApi isisApi;

    private ILogger<ActionInvocationService> logger;

    public ActionInvocationService(Api api, ApacheIsisApi isisApi, ILogger<ActionInvocationService> logger)
    {
       this.api = api; 
       this.isisApi = isisApi; 
       this.logger = logger; 
    }

    public async Task<IsisObject> InvokeAction(ObjectAction action,string title){
       
       return await isisApi.Load(action.invoke,title).ContinueWith(x=> {
           x.Wait();
            OnActionInvoked(x);
            return x.Result;
       }
       );
    }

    private async void OnActionInvoked(Task<IsisObject> task){
        if(ActionInvoked != null) {
            ActionInvoked(this,new ActionInvokedEventArgs(task.Result));
        }
    }

}

public class ActionInvokedEventArgs{
    public IsisObject Result{get;private set;}
    public ActionInvokedEventArgs(IsisObject result)
    {
       Result = result; 
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