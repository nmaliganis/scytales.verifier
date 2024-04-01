namespace mdoc.ui.Store.Verifiers.Actions.FetchWallet;

public class FetchWalletPendingAction
{
    public FetchWalletPendingAction(string presentationId)
    {
        this.PresentationId = presentationId;
    }

    public string PresentationId { get; set; }

}