using System;

public class ActionInvocationService{
    private Api api;
    public ActionInvocationService(Api api)
    {
       this.api = api; 
    }

    public object InvokeAction(Member action){
       throw new NotImplementedException(); 
    }
}