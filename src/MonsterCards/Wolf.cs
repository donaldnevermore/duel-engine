using DuelEngine.Cards;

namespace DuelEngine.MonsterCards {
    public sealed class Wolf : IMonster {
        public string Name { get; set; } = "Wolf";
        public string ID { get; set; } = "120105xxx";
        public string Text { get; set; } = "abc";
        public Attribute Attribute { get; set; } = Attribute.Fire;
        public bool IsLegend { get; set; } = false;
        public int Level { get; set; } = 3;
        public int Attack { get; set; } = 1100;
        public int Defense { get; set; } = 100;
        public Race Race { get; set; } = Race.Magician;
    }
}
