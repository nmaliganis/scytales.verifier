using System;
using System.Threading.Tasks;
using Quartz;

namespace mdoc.ui.Schedulers;

/// <summary>
/// Class : ReceivingWalletVerifierInitializerJob
/// </summary>
public class ReceivingWalletVerifierInitializerJob : IJob
{
    /// <summary>
    /// Method
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public Task Execute(IJobExecutionContext context)
    {

        return Task.CompletedTask;
    }
}