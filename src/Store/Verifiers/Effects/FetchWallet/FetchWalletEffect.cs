using System;
using System.Threading;
using System.Threading.Tasks;
using Fluxor;
using mdoc.ui.ServiceAgents.Contracts;
using mdoc.ui.Store.Verifiers.Actions.FetchWallet;
using Microsoft.Extensions.Hosting;

namespace mdoc.ui.Store.Verifiers.Effects.FetchWallet;

public class FetchWalletEffect : Effect<FetchWalletPendingAction>
{
    private IVerifyDataService VerifyService { get; set; }
    public FetchWalletEffect(IVerifyDataService verifyService)
    {
        this.VerifyService = verifyService;
    }

    public override async Task HandleAsync(FetchWalletPendingAction pendingAction, IDispatcher dispatcher)
    {
        try
        {
            var wallet = await VerifyService.ReceivingWallet(pendingAction.PresentationId);

            if (wallet is null)
                dispatcher.Dispatch(new FetchWalletFailedAction("Invalid Action"));
            else
                dispatcher.Dispatch(new FetchWalletSuccessAction(wallet));
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new FetchWalletFailedAction(e.Message));
        }
    }
}