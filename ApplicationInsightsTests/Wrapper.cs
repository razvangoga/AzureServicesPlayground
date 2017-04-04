using ApplicationInsightsForADLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationInsightsTests
{
    public class Wrapper
    {
        static Random random = new Random();
        public DateTime WrapWork()
        {
            int timeout = random.Next(10); 

            Thread.Sleep(timeout * 1000);

            Worker worker = new Worker();
            return worker.Work();
        }
    }
}
