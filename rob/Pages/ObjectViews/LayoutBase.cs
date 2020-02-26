using Microsoft.AspNetCore.Components;
using rob.API.ApacheISISApi;
using rob.API.ApacheISISApi.Representations.layout;

namespace rob.Pages.ObjectViews
{
    public  partial class LayoutBase : ComponentBase
    {
     
        [CascadingParameter(Name = "Context")] protected IsisSingleObject Context { get; set; }

        private ObjectLayout _layout;
        [CascadingParameter(Name = "Layout")]
        public ObjectLayout Layout
        {
            get { return _layout; }
            set
            {
                _layout = value;
                if (value != null)
                {
                    OnLayoutSet(value);
                }
                StateHasChanged();
            }}

        protected virtual void OnLayoutSet(ObjectLayout value)
        {}
    }
}
