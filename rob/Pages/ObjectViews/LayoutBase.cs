using System;
using Microsoft.AspNetCore.Components;
using rob.API.ApacheISISApi;

namespace rob.Pages.ObjectViews
{
    public  partial class LayoutBase<TLayout> : ComponentBase
    {
     
        [Parameter]
        public IsisSingleObject Context { get; set; }
        
        [Parameter]
        public UnrefencedMembersFilter Unreferenced { get; set; }

        private TLayout _layout;
        [Parameter]
        public TLayout Layout
        {
            get => _layout;
            set
            {
                _layout = value;
                if (value != null)
                {
                    OnLayoutSet(value);
                }
                StateHasChanged();
            }}

        protected virtual void OnLayoutSet(TLayout value){}
    }
}
