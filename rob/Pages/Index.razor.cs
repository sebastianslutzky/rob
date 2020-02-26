
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using rob.Services;
using rob.API.ApacheISISApi;
using rob.API.ApacheISISApi.Representations;
using rob.API.ApacheISISApi.Representations.layout;

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

        [Inject]
        protected Api RestFulObjectsApi { get; set; }

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

        private ObjectLayout ObjectLayout { get; set; }

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
            var isisObject = await this.IsisApi.LoadAsIsisSingleObject(new Link() { href = url, method = "Get" });
            this.FocusObject = isisObject;
            this.ObjectLayout = await this.RestFulObjectsApi.Load<ObjectLayout>(isisObject.Layout);
            StateHasChanged();
        }
    } 
}