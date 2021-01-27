using DuelEngine.Domain;

namespace DuelEngine.MonsterCards {
    public sealed class DarkSorcerer : MonsterCard {
        public string Name { get; set; } = "Dark Sorcerer";
        public string ID { get; set; } = "120105005";
        public string Text { get; set; } = "abc";
        public Attribute Attribute { get; set; } = Attribute.Dark;
        public bool IsLegend { get; set; } = false;
        public int Level { get; set; } = 4;
        public int Attack { get; set; } = 1500;
        public int Defense { get; set; } = 0;
        public Race Race { get; set; } = Race.Magician;
    }
}
