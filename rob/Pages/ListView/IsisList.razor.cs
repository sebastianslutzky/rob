using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace rob.Pages.ListView {
 public partial class IsisList:ComponentBase{
   [Parameter]
    public IsisObject Context{get;set;}

    private string getObjectUrl(JToken resultObject){
      return "object/" + System.Uri.EscapeDataString((string)resultObject["$$href"]);
    }
 }
}