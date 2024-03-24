using System.Threading.Tasks;
using mdoc.ui.Models.PidPresentationDefinitions;

namespace mdoc.ui.ServiceAgents.Contracts;

public interface IVerifyDataService
{
    Task<PresentationDto> InitializePresentation(string payload);
    Task<PresentationDto> ReceivingWallet(string presentationId);
}