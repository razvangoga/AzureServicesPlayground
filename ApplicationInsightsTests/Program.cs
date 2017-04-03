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
            string ikey = "";

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

            Console.WriteLine("Done...");
            Console.ReadKey();
        }
    }
}
