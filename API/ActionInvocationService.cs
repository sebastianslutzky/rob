using System;

/// Takes care of calling an action with the right parameters, verb and headers (api)
public class ActionInvocationService{
    private Api api;
    public ActionInvocationService(Api api)
    {
       this.api = api; 
    }

    public object InvokeAction(Member action){
       throw new NotImplementedException(); 
       // If needs parameters, send out an event or use a ParameterCollector service
       // Once parameters are collected, send ParameterCollection and descriptor to API.
    }

}