namespace TimeSynchronization
{
    public interface ITimes
    {
        int WorldTime { get; }
        int GameTime { get; }
    }
}