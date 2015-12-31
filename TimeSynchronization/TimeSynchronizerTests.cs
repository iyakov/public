using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace TimeSynchronization
{
    [TestFixture]
    public sealed class TimeSynchronizerTests
    {
        private TimeSynchronizer _underTest;

        [SetUp]
        public void Setup()
        {
            _underTest = new TimeSynchronizer
            {
                Server = { WorldTime = 100 },
                Client = { WorldTime = 370 }
            };
        }

        [Test]
        public void Initialization_Should_InitializeProperties()
        {
            _underTest.ShouldBeEquivalentTo(new TimeSynchronizer
            {
                Server = { WorldTime = 100, GameTime = 0 },
                Client = { WorldTime = 370, GameTime = 0 }
            });
        }

        [Test]
        public void GetSnapshot_Should_CopyTimes()
        {
            _underTest.GetSnapshot().ShouldBeEquivalentTo(new Snapshot
            {
                Server = new Times { WorldTime = 100, GameTime = 0 },
                Client = new Times { WorldTime = 370, GameTime = 0 }
            });

            _underTest.Tick(99);

            _underTest.GetSnapshot().ShouldBeEquivalentTo(new Snapshot
            {
                Server = new Times { WorldTime = 199, GameTime = 99 },
                Client = new Times { WorldTime = 469, GameTime = 99 }
            });
        }

        [Test]
        public void Tick_Should_MoveTimesForward()
        {
            _underTest.Tick(5);

            _underTest.ShouldBeEquivalentTo(new TimeSynchronizer
            {
                Server = { WorldTime = 105, GameTime = 5 },
                Client = { WorldTime = 375, GameTime = 5 }
            });

            _underTest.Tick(10);

            _underTest.ShouldBeEquivalentTo(new TimeSynchronizer
            {
                Server = { WorldTime = 115, GameTime = 15 },
                Client = { WorldTime = 385, GameTime = 15 }
            });
        }

        [Test]
        public void TickReal_Should_ChangeTimes()
        {
            _underTest.TickReal(5);

            _underTest.ShouldBeEquivalentTo(new TimeSynchronizer
            {
                Server = { WorldTime = 105, GameTime = 5 },
                Client = { WorldTime = 376, GameTime = 4 }
            });

            _underTest.TickReal(10);

            _underTest.ShouldBeEquivalentTo(new TimeSynchronizer
            {
                Server = { WorldTime = 115, GameTime = 15 },
                Client = { WorldTime = 387, GameTime = 13 }
            });
        }
    }
}
