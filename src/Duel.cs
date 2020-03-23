namespace DuelEngine
{
    public class Duel
    {
        public Phase Phase { get; } = Phase.Standby;
        public uint Turn { get; set; } = 1;
    }
}
