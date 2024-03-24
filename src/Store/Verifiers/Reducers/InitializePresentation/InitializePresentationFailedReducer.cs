using Fluxor;
using mdoc.ui.Store.Verifiers.Actions.InitializePresentation;

namespace mdoc.ui.Store.Verifiers.Reducers.InitializePresentation;

public class InitializePresentationFailedReducer : Reducer<VerifyState, InitializePresentationFailedAction>
{
    public override VerifyState Reduce(VerifyState state, InitializePresentationFailedAction action)
    {
        return new VerifyState(
            action.Message,
            false,
            state.Presentation,
            state.QrUri
        );
    }
}