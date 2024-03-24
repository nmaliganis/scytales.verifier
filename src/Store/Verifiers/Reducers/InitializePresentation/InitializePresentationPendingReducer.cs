using Fluxor;
using mdoc.ui.Store.Verifiers.Actions.InitializePresentation;

namespace mdoc.ui.Store.Verifiers.Reducers.InitializePresentation;

public class InitializePresentationPendingReducer : Reducer<VerifyState, InitializePresentationPendingAction>
{
    public override VerifyState Reduce(VerifyState state, InitializePresentationPendingAction pendingAction)
    {
        return new VerifyState(
            string.Empty,
            true,
            state.Presentation,
            state.QrUri
        );
    }
}