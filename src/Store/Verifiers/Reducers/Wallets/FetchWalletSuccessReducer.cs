using Fluxor;
using mdoc.ui.Helpers;
using mdoc.ui.Store.Verifiers.Actions.FetchWallet;
using Microsoft.AspNetCore.Mvc.Routing;

namespace mdoc.ui.Store.Verifiers.Reducers.Wallets;

public class FetchWalletSuccessReducer : Reducer<WalletState, FetchWalletSuccessAction>
{
    public override WalletState Reduce(WalletState state, FetchWalletSuccessAction action)
    {
        return new WalletState(
            string.Empty,
            false,
            true,
            action.Token
        );
    }
}