using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using mdoc.ui.Store.Verifiers;
using mdoc.ui.Store.Verifiers.Actions.FetchWallet;
using mdoc.ui.Store.Verifiers.Actions.InitializePresentation;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using Telerik.Blazor.Components;
using Timer = System.Timers.Timer;

namespace mdoc.ui.Pages.Login
{
    public class LoginViewModel : FluxorComponent
    {
        [Inject] public IDispatcher Dispatcher { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IConfiguration Configuration { get; set; }

        [Inject] public IState<VerifyState> VerifyState { get; set; }
        [Inject] public IState<WalletState> WalletState { get; set; }

        public bool SubmitValidated { get; set; } = false;

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
                FirstRendered();
            }
        }

        private void FirstRendered()
        {
            this.Dispatcher.Dispatch(new InitializePresentationPendingAction());
            Thread.Sleep(1000);
            this.SubmitValidated = true;
        }

        public TelerikNotification NotificationComponent { get; set; }

        public void ShowSuccessLogin()
        {
            this.NotificationComponent.Show(new NotificationModel()
            {
                Text = "Success!",
                ThemeColor = "success",
                ShowIcon = true,
                Icon = "file-add",
            });
            ValidateStatusControlAfterSuccess();
        }

        private void ValidateStatusControlAfterSuccess()
        {
            this.SubmitValidated = false;
        }

        public void ShowErrorLogin()
        {
            this.NotificationComponent.Show(new NotificationModel()
            {
                Text = "Error!",
                ThemeColor = "error",
                ShowIcon = true,
                Icon = "file-error",
            });
            ValidateStatusControlAfterError();
        }

        private void ValidateStatusControlAfterError()
        {
            this.SubmitValidated = false;
        }

        #region Timer

        private Timer _timer;

        protected void CheckIfVerifiedQrWasScanned()
        {
            SetTimer(2000);
            this.SubmitValidated = true;
        }

        public void SetTimer(double interval)
        {
            this._timer = new Timer(interval);
            this._timer.Elapsed += this.NotifyTimerElapsed;
            this._timer.Enabled = true;
        }

        private void NotifyTimerElapsed(object sender, ElapsedEventArgs e)
        {
            this._timer.Enabled = false;
            OnElapsed?.Invoke();
            this._timer.Dispose();
            if (!this.WalletState.Value.IsTokenFetched)
            {
                this.Dispatcher.Dispatch(new FetchWalletPendingAction(this.VerifyState.Value.Presentation.presentation_id));
            }
            else
            {
                ShowSuccessLogin();
                Thread.Sleep(1000);
                this.InvokeAsync(() => this.NavigationManager.NavigateTo($"dashboard"));
            }

            this._timer.Dispose();
        }

        public event Action OnElapsed;

        #endregion
    }
}