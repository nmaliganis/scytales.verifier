using System.Security.Policy;
using System.Text;

namespace mdoc.ui.Helpers;

public static class UriBuilder
{
    public static string BuildUri(string verifierBackendDomain, string jwtToken)
    {
        int lastIndex = jwtToken.LastIndexOf('/');

        string jwt = jwtToken.Substring(lastIndex + 1);

        StringBuilder builder = new StringBuilder();
        builder.Append("eudi-openid4vp://");
        builder.Append(verifierBackendDomain);
        builder.Append("?client_id=");
        builder.Append(verifierBackendDomain);
        builder.Append("&request_uri=https%3A%2F%2F");
        builder.Append(verifierBackendDomain);
        builder.Append("%2Fwallet%2Frequest.jwt%2F");
        builder.Append(jwt);

        return builder.ToString();
    }
}