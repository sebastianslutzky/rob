
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using rob.Services;
using rob.API.ApacheISISApi;

namespace rob.Pages{
    public partial class Index: ComponentBase{
    [Inject]
    protected ActionInvocationService Invoker { get; set; }
    [Inject]
    protected ObjectLoadedPublisherService Publisher { get; set; }
         [Inject]
    protected ILogger<Index> Logger{get;set;}
        [Inject]
        protected ApacheIsisApi IsisApi { get; set; }

        [Parameter]
        public string Resource { get; set; }

        private IDisplayableObject _focusObject;

        private IsisObject FocusObjectAsIsisObject => FocusObject as IsisObject;
        private IsisSingleObject FocusObjectAsIsisSingleObject => FocusObject as IsisSingleObject;

        private IDisplayableObject FocusObject
        {
        get { return _focusObject;}
        set { 
            _focusObject = value;
            StateHasChanged();
            }}

        public async override Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);
            if (RoutedToObject())
            {
                LoadSingleObject(Resource);
            }
        }

   
        protected override async Task OnInitializedAsync()
        {
            this.Invoker.ActionInvoked += (s, e) =>
            {
                this.FocusObject = e.Result;
            };
        }
    
        private bool RoutedToObject()
        {
            return !string.IsNullOrEmpty(Resource);
        }

        private async void LoadSingleObject(string url)
        {
            this.FocusObject  = await this.IsisApi.LoadAsIsisSingleObject(new Link() { href = url, method = "Get" });
        }
    } 
}