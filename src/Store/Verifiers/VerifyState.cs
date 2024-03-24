using mdoc.ui.Models.PidPresentationDefinitions;

namespace mdoc.ui.Store.Verifiers;

public class VerifyState
{
    public bool IsLoading { get; private set; }
    public string ErrorMessage { get; private set; }
    public string QrUri { get; private set; }
    public PresentationDto Presentation { get; private set; }

    public VerifyState(
        string errorMessage,
        bool isLoading, PresentationDto presentation, string qrUri)
    {
        this.ErrorMessage = errorMessage;
        this.IsLoading = isLoading;
        this.Presentation = presentation;
        this.QrUri = qrUri;
    }
}