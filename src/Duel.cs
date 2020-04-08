namespace DuelEngine
{
    public class Duel
    {
        public Phase Phase { get; } = Phase.Draw;
        public uint Turn { get; set; } = 1;
    }
}
