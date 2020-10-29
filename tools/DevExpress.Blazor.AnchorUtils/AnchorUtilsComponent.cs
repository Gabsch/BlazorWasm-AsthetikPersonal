using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using Microsoft.JSInterop.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevExpress.Blazor.AnchorUtils
{
    public class AnchorUtilsComponent : ComponentBase, IDisposable
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }

        private Task<IJSObjectReference> module;

        public Task<IJSObjectReference> Module { get => module ??= JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/DevExpress.Blazor.AnchorUtils/anchor-utils.js").AsTask(); }
        string Anchor { get; set; }

        bool ForceScroll { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            NavigationManager.LocationChanged += OnLocationChanged;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                await ScrollToAnchor(forceScroll: true);

            await base.OnAfterRenderAsync(firstRender);
        }

        async void OnLocationChanged(object sender, LocationChangedEventArgs args)
        {
            await ScrollToAnchor(NavigationManager.ToAbsoluteUri(args.Location).Fragment);
        }

        private async Task ScrollToAnchor(string anchor = "", bool forceScroll = false)
        {
            var module = await Module;
            if (!string.IsNullOrEmpty(anchor) || forceScroll)
                await module.InvokeAsync<string>("scrollToAnchor", anchor);
        }

        void IDisposable.Dispose()
        {
            NavigationManager.LocationChanged -= OnLocationChanged;
        }
    }
}