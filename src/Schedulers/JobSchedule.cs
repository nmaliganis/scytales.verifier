using System;

namespace mdoc.ui.Schedulers;

/// <summary>
/// Class
/// </summary>
public class JobSchedule
{
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="jobType"></param>
    /// <param name="cronExpression"></param>
    public JobSchedule(Type jobType, string cronExpression)
    {
        JobType = jobType;
        CronExpression = cronExpression;
    }

    /// <summary>
    /// Prop
    /// </summary>
    public Type JobType { get; }
    /// <summary>
    /// Prop
    /// </summary>
    public string CronExpression { get; }
}