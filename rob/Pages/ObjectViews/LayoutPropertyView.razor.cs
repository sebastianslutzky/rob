using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Components;
using rob.API.ApacheISISApi;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using System.Threading.Tasks;
using RestfulObjectApi.Representation.Types;

namespace rob.Pages.ObjectViews{


    public partial class LayoutPropertyView
    {
        private string _format;
        private ObjectMemberInstance _propertyDetails;
        private ActionDescription _propertyDescriptor;
        private string _friendlyName;
        [Inject]
        private Api Api { get; set; }
        [Inject]
        protected ILogger<LayoutPropertyView> Logger{get;set;}
        [Parameter]
        public Member Property { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            _format = Property.extensions.format;
            _propertyDetails = await Api.Load<ObjectMemberInstance>(Property.details);
            _propertyDescriptor = await Api.Load<ActionDescription>(_propertyDetails.DescribedBy);
            _friendlyName = _propertyDescriptor.extensions.friendlyName;
            Logger.LogInformation(_propertyDetails);
        }
    }
}
