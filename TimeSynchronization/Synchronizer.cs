using System;

namespace TimeSynchronization
{
    public static class Synchronizer
    {
        public static void PrepareSynchronize(
            ITimes client, ITimes server)
        {
            // add some code here
        }

        public static void FinishSynchronize(
            ITimes client, ITimes server, Action<Times> clientTimeSetter)
        {
            // add some code here
        }
    }
}
