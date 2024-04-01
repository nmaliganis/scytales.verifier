using Fluxor;
using mdoc.ui.Store.Verifiers.Actions.FetchWallet;

namespace mdoc.ui.Store.Verifiers.Reducers.Wallets;

public class FetchWalletPendingReducer : Reducer<WalletState, FetchWalletPendingAction>
{
    public override WalletState Reduce(WalletState state, FetchWalletPendingAction pendingAction)
    {
        return new WalletState(
            string.Empty,
            true,
            state.IsTokenFetched,
            state.Token
        );
    }
}