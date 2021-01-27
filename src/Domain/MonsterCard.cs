namespace DuelEngine.Domain {
    public interface MonsterCard : Card {
        Attribute Attribute { get; set; }
        bool IsLegend { get; set; }
        int Level { get; set; }
        int Attack { get; set; }
        int Defense { get; set; }
        Race Race { get; set; }
    }
}
