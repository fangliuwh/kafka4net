﻿using System.Reactive.Concurrency;
using System.Threading;

namespace kafka4net.Utils
{
    /// <summary>
    /// Implements SynchronizationContext which routes "async" keyword callbacks to Rx Scheduler
    /// </summary>
    class RxSyncContextFromScheduler : SynchronizationContext
    {
        private readonly IScheduler _scheduler;
        static readonly ILogger _log = Logger.GetLogger();

        public RxSyncContextFromScheduler(IScheduler scheduler) 
        {
            _scheduler = scheduler;
        }

        public override void Post(SendOrPostCallback d, object state)
        {
            _scheduler.Schedule(() => d(state));
        }
    }
}
