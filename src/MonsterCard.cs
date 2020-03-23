namespace DuelEngine
{
    public class MonsterCard
    {
        public int Level { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public MonsterCard(int level, int attack, int defense)
        {
            Level = level;
            Attack = attack;
            Defense = defense;
        }
    }
}
