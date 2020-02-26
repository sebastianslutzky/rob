﻿using Microsoft.AspNetCore.Components;
using rob.API.ApacheISISApi;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using System.Threading.Tasks;
using rob.API.ApacheISISApi.Representations.layout;

namespace rob.Pages.ObjectViews{

    public partial class LayoutGridView:LayoutBase
    {
        [Inject]
        protected ILogger<LayoutGridView> Logger{get;set;}
        private LayoutRow[] Rows;

        protected override void OnLayoutSet(ObjectLayout value)
        {
            base.OnLayoutSet(value);
            Rows = value.row;
        }
    }
}
