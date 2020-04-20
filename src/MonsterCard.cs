namespace DuelEngine {
    public class MonsterCard {
        public uint Level { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public MonsterCard(uint level, int attack, int defense) {
            Level = level;
            Attack = attack;
            Defense = defense;
        }
    }
}
