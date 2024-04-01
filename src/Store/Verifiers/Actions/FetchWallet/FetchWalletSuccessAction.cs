using mdoc.ui.Models.PidPresentationDefinitions;

namespace mdoc.ui.Store.Verifiers.Actions.FetchWallet;

public class FetchWalletSuccessAction
{
    public string Token { get; }

    public FetchWalletSuccessAction(string token)
    {
        this.Token = token;
    }
}