using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TimeSynchronization
{
    public sealed class Program
    {
        private static readonly TimeSynchronizer Times = new TimeSynchronizer
        {
            Client = { WorldTime = 370 },
            Server = { WorldTime = 100 }
        };

        public static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Times.TickReal(10);
            }

            // insert your code here

        }
    }
}
