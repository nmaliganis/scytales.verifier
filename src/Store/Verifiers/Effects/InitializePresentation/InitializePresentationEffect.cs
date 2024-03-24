using System;
using System.Threading;
using System.Threading.Tasks;
using Fluxor;
using mdoc.ui.Schedulers;
using mdoc.ui.ServiceAgents.Contracts;
using mdoc.ui.Store.Verifiers.Actions.InitializePresentation;
using Microsoft.Extensions.Hosting;

namespace mdoc.ui.Store.Verifiers.Effects.InitializePresentation;

public class InitializePresentationEffect : Effect<InitializePresentationPendingAction>
{
    private IVerifyDataService VerifyService { get; set; }
    public InitializePresentationEffect(IVerifyDataService verifyService)
    {
        this.VerifyService = verifyService;
    }

    public override async Task HandleAsync(InitializePresentationPendingAction pendingAction, IDispatcher dispatcher)
    {
        try
        {
            var presentation = await VerifyService.InitializePresentation(pendingAction.Payload);

            if (presentation is null)
                dispatcher.Dispatch(new InitializePresentationFailedAction("Invalid Action"));
            else
                dispatcher.Dispatch(new InitializePresentationSuccessAction(presentation));
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new InitializePresentationFailedAction(e.Message));
        }
    }
}