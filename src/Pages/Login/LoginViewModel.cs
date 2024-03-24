using System;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using mdoc.ui.Store.Verifiers;
using mdoc.ui.Store.Verifiers.Actions.InitializePresentation;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;

namespace mdoc.ui.Pages.Login
{
    public class LoginViewModel : FluxorComponent
    {
        [Inject] public IDispatcher Dispatcher { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IConfiguration Configuration { get; set; }

        [Inject] public IState<VerifyState> VerifyState { get; set; }

        #region Initialization

        protected override Task OnInitializedAsync()
        {
            this.StateHasChanged();
            return base.OnInitializedAsync();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                this.Dispatcher.Dispatch(new InitializePresentationPendingAction());
            }
        }
    }
}