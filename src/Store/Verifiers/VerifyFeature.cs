using Fluxor;
using mdoc.ui.Models.PidPresentationDefinitions;

namespace mdoc.ui.Store.Verifiers;

public class VerifyFeature : Feature<VerifyState>
{
    public override string GetName() => "Verify";

    protected override VerifyState GetInitialState() => new VerifyState(
        string.Empty,
        true,
        new PresentationDto(),
        string.Empty
    );
}