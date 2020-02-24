using Microsoft.AspNetCore.Components;
using rob.API.ApacheISISApi;

namespace rob.Pages.ObjectView{
    public partial class ObjectView
    {
        [CascadingParameter]
        public IsisSingleObject Context { get; set; }
        
    
    }
}
