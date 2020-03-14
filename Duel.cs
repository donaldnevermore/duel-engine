namespace DuelEngine
{
    public class Duel
    {
        public EPhase Phase { get; } = EPhase.Standby;
        public uint Turn { get; set; } = 1;
    }
}
