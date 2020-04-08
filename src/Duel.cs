namespace DuelEngine
{
    public class Duel
    {
        public Phase Phase { get; set; } = Phase.Draw;
        public uint Turn { get; set; } = 1;

        public bool IsFirstTurn()
        {
            return Turn == 1;
        }
    }
}
