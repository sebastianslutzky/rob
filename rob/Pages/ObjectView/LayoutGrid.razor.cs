using Microsoft.AspNetCore.Components;
using rob.API.ApacheISISApi;

namespace rob.Pages.ObjectView{
    public partial class LayoutGrid
    {
        [CascadingParameter]
        public IsisSingleObject Context { get; set; }


    
    }
}
