using System;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using RestfulObjectApi.Representation.Types;
using Blazor.Extensions.Logging;
using rob.API.ApacheISISApi;

namespace rob.Services
{
    public class ObjectLoadedPublisherService
    {
           private ILogger<ObjectLoadedPublisherService> Logger{get;}
           public event EventHandler<ObjectLoadedEventArgs> ObjectLoaded;
           public void Publish(Object sender,IsisSingleObject target){
               if(this.ObjectLoaded != null){
                this.ObjectLoaded(this,new ObjectLoadedEventArgs(target));
               }
           }

           public ObjectLoadedPublisherService(ILogger<ObjectLoadedPublisherService> logger)
           {
               Logger = logger;
           }
    }
 public class ObjectLoadedEventArgs {
     public IsisSingleObject Object {get;}
     public ObjectLoadedEventArgs(IsisSingleObject context)
     {
        Object = context; 
     }
   }
}