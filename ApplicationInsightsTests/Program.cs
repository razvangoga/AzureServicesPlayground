using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInsightsTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string ikey = "ai integration key";

            TelemetryConfiguration.Active.InstrumentationKey = ikey;
            TelemetryConfiguration.Active.TelemetryChannel.DeveloperMode = true;

            string key = "ConsoleTest";

            Trace.TraceError($"{key} - error");
            Trace.TraceInformation($"{key} - info");
            Trace.TraceWarning($"{key} - warning");
            Trace.Write($"{key} - write", "my category");

            //TraceSource ts = new TraceSource("My Verbose Debugger") { Switch = { Level = SourceLevels.All } };
            //ts.TraceData(TraceEventType.Verbose, 0, $"{key} - verbose");
            //ts.Flush();
            TelemetryClient telemetry = new TelemetryClient();

            for (int i = 0; i < 20; i++)
            {
                var startTime = DateTime.UtcNow;
                var timer = Stopwatch.StartNew();
                try
                {
                    Wrapper wrapper = new Wrapper();
                    wrapper.WrapWork();
                }
                finally
                {
                    timer.Stop();
                    telemetry.TrackDependency("myDependency", "myCall", startTime, timer.Elapsed, true);
                }

                Console.WriteLine(i);
            }

            Console.WriteLine("Done...");
            Console.ReadKey();
        }
    }
}
