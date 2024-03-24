using System;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace mdoc.ui.Schedulers;

/// <summary>
/// Class
/// </summary>
public class JobFactory : IJobFactory
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="serviceProvider"></param>
    public JobFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="bundle"></param>
    /// <param name="scheduler"></param>
    /// <returns></returns>
    public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
    {
        return _serviceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob;
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="job"></param>
    public void ReturnJob(IJob job)
    {
        // we let the DI container handler this
    }
}