using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace rob.Pages.ObjectViews.Property{


    public partial class StringPropertyView
    {
        [Parameter]
        public string Name { get; set; }
        private string Value { get; set; }
        
        [Inject]
        protected ILogger<StringPropertyView> Logger{get;set;}
        [Parameter]
        public Member Property { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            Value = Property.value;
        }
      
    }
}
