using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;

namespace ApplicationInsightsForADLL
{
    public class Worker
    {
        static Random random = new Random();
        TelemetryClient telemetry = new TelemetryClient();
        public DateTime Work()
        {
            var startTime = DateTime.UtcNow;
            var timer = Stopwatch.StartNew();
            try
            {
                int timeout = random.Next(10);
                Thread.Sleep(timeout * 1000);
            }
            finally
            {
                timer.Stop();
                telemetry.TrackDependency("myDependency", "myCallInner", startTime, timer.Elapsed, true);
            }

            return DateTime.UtcNow;
        }
    }
}
