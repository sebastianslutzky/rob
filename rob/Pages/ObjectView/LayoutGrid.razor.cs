using Microsoft.AspNetCore.Components;
using rob.API.ApacheISISApi;

namespace rob.Pages.ObjectView{
    public partial class ObjectView
    {
        [Parameter]
        public IsisSingleObject Context { get; set; }


    
    }
}
