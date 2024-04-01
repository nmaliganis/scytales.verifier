using System;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using mdoc.ui.Store.Verifiers;
using mdoc.ui.Store.Verifiers.Actions.InitializePresentation;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;

namespace mdoc.ui.Pages.Dashboard
{
    public class DashboardViewModel : FluxorComponent
    {
        [Inject] public IDispatcher Dispatcher { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IConfiguration Configuration { get; set; }

        [Inject] public IState<VerifyState> VerifyState { get; set; }
        [Inject] public IState<WalletState> WalletState { get; set; }

        public string VpToken { get; set; }

        #region Initialization

        protected override Task OnInitializedAsync()
        {
            this.VpToken = WalletState.Value.Token;
            StateHasChanged();
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

        protected void OnInitializePresentationClickHandler()
        {
            Dispatcher.Dispatch(new InitializePresentationPendingAction());
        }
    }
}