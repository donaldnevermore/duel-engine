namespace DuelEngine {
    public class Duel {
        public Phase Phase { get; set; } = Phase.Draw;
        public int Turn { get; set; } = 1;
        public int InitialDrawNumber { get; set; }
        public int DrawLimit { get; set; }
        public int ZoneNumber { get; set; }
        public int LifePoint { get; set; }
        public int DeckLimit { get; set; }

        public bool IsFirstTurn() {
            return Turn == 1;
        }
    }
}
