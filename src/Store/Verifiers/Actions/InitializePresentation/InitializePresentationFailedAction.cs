namespace mdoc.ui.Store.Verifiers.Actions.InitializePresentation;

public class InitializePresentationFailedAction
{
    public string Message { get; }

    public InitializePresentationFailedAction(string message)
    {
        this.Message = message;
    }
}