using System;
using System.Diagnostics;

namespace TimeSynchronization
{
    public sealed class TimeSynchronizer
    {
        public TimeSynchronizer()
        {
            Client = new Times();
            Server = new Times();
        }

        public Times Client { get; set; }
        public Times Server { get; set; }

        public void Tick(int time)
        {
            Debug.Assert(time > 0);

            Client.WorldTime += time;
            Client.GameTime += time;

            Server.WorldTime += time;
            Server.GameTime += time;
        }

        public void TickReal(int time)
        {
            Client.WorldTime += time + 1;
            Client.GameTime += time - 1;

            Server.WorldTime += time;
            Server.GameTime += time;
        }

        public Snapshot GetSnapshot()
        {
            return new Snapshot
            {
                Client = new Times { WorldTime = Client.WorldTime, GameTime = Client.GameTime },
                Server = new Times { WorldTime = Server.WorldTime, GameTime = Server.GameTime },
            };
        }
    }
}