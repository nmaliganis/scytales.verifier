using Fluxor;
using mdoc.ui.Models.PidPresentationDefinitions;

namespace mdoc.ui.Store.Verifiers;

public class WalletFeature : Feature<WalletState>
{
    public override string GetName() => "Wallet";

    protected override WalletState GetInitialState() => new WalletState(
        string.Empty,
        false,
        false,
        string.Empty
    );
}