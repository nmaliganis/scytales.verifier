namespace mdoc.ui.Store.Verifiers.Actions.FetchWallet;

public class FetchWalletFailedAction
{
    public string Message { get; }

    public FetchWalletFailedAction(string message)
    {
        this.Message = message;
    }
}