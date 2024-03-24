using Fluxor;
using mdoc.ui.Helpers;
using mdoc.ui.Store.Verifiers.Actions.InitializePresentation;

namespace mdoc.ui.Store.Verifiers.Reducers.InitializePresentation;

public class InitializePresentationSuccessReducer : Reducer<VerifyState, InitializePresentationSuccessAction>
{
    public override VerifyState Reduce(VerifyState state, InitializePresentationSuccessAction action)
    {
        return new VerifyState(
            string.Empty,
            false,
            action.Presentation,
            UriBuilder.BuildUri(action.Presentation.client_id, action.Presentation.request_uri)
        );
    }
}