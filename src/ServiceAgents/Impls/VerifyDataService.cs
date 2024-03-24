using System;
using System.Net;
using System.Threading.Tasks;
using mdoc.ui.Models.PidPresentationDefinitions;
using mdoc.ui.ServiceAgents.Base;
using mdoc.ui.ServiceAgents.Contracts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace mdoc.ui.ServiceAgents.Impls;

public class VerifyDataService : IVerifyDataService
{
    public IConfiguration Configuration { get; set; }
    public string BaseAddr { get; private set; }
    public string Version { get; private set; }

    public VerifyDataService(IConfiguration configuration)
    {
        Configuration = configuration;
        OnCreated();
    }

    private void OnCreated()
    {
        this.BaseAddr = Configuration["url"];
        this.Version = Configuration["version"];
    }

    public async Task<PresentationDto> InitializePresentation(string payload)
    {
        PresentationDto result = new PresentationDto();

        var client = new RestClient($"{BaseAddr}");
        var request = new RestRequest();

        request.AddBody(payload);
        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.ExecutePostAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<PresentationDto>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                VerifyErrorModel resultError =
                    JsonConvert.DeserializeObject<VerifyErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                VerifyErrorModel resultError =
                    JsonConvert.DeserializeObject<VerifyErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                VerifyErrorModel resultError =
                    JsonConvert.DeserializeObject<VerifyErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                VerifyErrorModel resultError =
                    JsonConvert.DeserializeObject<VerifyErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                VerifyErrorModel resultError =
                    JsonConvert.DeserializeObject<VerifyErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    VerifyErrorModel resultError =
                        JsonConvert.DeserializeObject<VerifyErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }

        return result;
    }

    public Task<PresentationDto> ReceivingWallet(string presentationId)
    {
        throw new NotImplementedException();
    }
}