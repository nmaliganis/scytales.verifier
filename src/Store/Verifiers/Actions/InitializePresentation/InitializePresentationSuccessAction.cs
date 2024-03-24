using mdoc.ui.Models.PidPresentationDefinitions;

namespace mdoc.ui.Store.Verifiers.Actions.InitializePresentation;

public class InitializePresentationSuccessAction
{
    public PresentationDto Presentation { get; }

    public InitializePresentationSuccessAction(PresentationDto presentation)
    {
        this.Presentation = presentation;
    }
}