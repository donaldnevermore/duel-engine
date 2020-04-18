namespace DuelEngine {
    public class Duel {
        public Phase Phase { get; set; } = Phase.Draw;
        public uint Turn { get; set; } = 1;
        public uint InitialDrawNumber { get; set; }
        public uint DrawLimit { get; set; }
        public uint ZoneNumber { get; set; }
        public int LifePoint { get; set; }

        public bool IsFirstTurn() {
            return Turn == 1;
        }
    }
}
