using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Components;
using rob.API.ApacheISISApi;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using System.Threading.Tasks;
using RestfulObjectApi.Representation.Types;
using rob.layout.representations;

namespace rob.Pages.ObjectViews{


    public partial class LayoutPropertyView
    {
        private string _format;

        [Inject]
        protected ILogger<LayoutPropertyView> Logger{get;set;}
        [Parameter]
        public Member Property { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            _format = Property.extensions.format;
        }
      
    }
}
