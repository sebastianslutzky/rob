using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace rob.Pages.ObjectViews {
 public partial class IsisList:ComponentBase{
   [Parameter]
    public IsisObject Context{get;set;}
 }
}