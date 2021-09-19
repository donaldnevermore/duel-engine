using DuelEngine.Domain;

namespace DuelEngine.MonsterCards {
    public sealed class SpellArcher : MonsterCard {
        public string Name { get; set; } = "Spell Archer";
        public string Id { get; set; } = "120105008";
        public string Text { get; set; } = "abc";
        public Attribute Attribute { get; set; } = Attribute.Wind;
        public bool IsLegend { get; set; } = false;
        public int Level { get; set; } = 3;
        public int Attack { get; set; } = 1000;
        public int Defense { get; set; } = 400;
        public Race Race { get; set; } = Race.Magician;
    }
}
