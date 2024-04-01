using Fluxor;
using mdoc.ui.Store.Verifiers.Actions.FetchWallet;

namespace mdoc.ui.Store.Verifiers.Reducers.Wallets;

public class FetchWalletFailedReducer : Reducer<WalletState, FetchWalletFailedAction>
{
    public override WalletState Reduce(WalletState state, FetchWalletFailedAction action)
    {
        return new WalletState(
            action.Message,
            false,
            state.IsTokenFetched,
            state.Token
        );
    }
}