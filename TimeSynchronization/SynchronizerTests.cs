using FluentAssertions;
using NUnit.Framework;

namespace TimeSynchronization
{
    [TestFixture]
    public sealed class SynchronizerTests
    {
        private ApplicationTimes _underTest;

        [SetUp]
        public void Setup()
        {
            _underTest = new ApplicationTimes
            {
                Server = { WorldTime = 100 },
                Client = { WorldTime = 370 }
            };
        }

        [Test]
        public void Time_Should_BeSynchronized()
        {
            for (int i = 0; i < 10; i++)
            {
                _underTest.TickReal(10);
            }

            Synchronizer.PrepareSynchronize(
                _underTest.Client,
                _underTest.Server);

            _underTest.TickReal(1);

            Synchronizer.FinishSynchronize(
                _underTest.Client,
                _underTest.Server,
                value => _underTest.Client = value);

            _underTest.Client.ShouldBeEquivalentTo(
                _underTest.Server);
        }
    }
}
