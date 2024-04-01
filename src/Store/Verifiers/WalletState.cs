using mdoc.ui.Models.PidPresentationDefinitions;

namespace mdoc.ui.Store.Verifiers;

public class WalletState
{
    public bool IsLoading { get; private set; }
    public string ErrorMessage { get; private set; }
    public bool IsTokenFetched { get; private set; }
    public string Token { get; private set; }

    public WalletState(
        string errorMessage,
        bool isLoading, bool isTokenFetched, string token)
    {
        this.ErrorMessage = errorMessage;
        this.IsLoading = isLoading;
        this.IsTokenFetched = isTokenFetched;
        this.Token = token;
    }
}