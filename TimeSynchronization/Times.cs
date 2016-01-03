namespace TimeSynchronization
{
    public sealed class Times : ITimes
    {
        public int WorldTime { get; set; }
        public int GameTime { get; set; }
    }
}