namespace DuelEngine.Cards {
    public interface IMonsterCard : ICard {
        Attribute Attribute { get; set; }
        bool IsLegend { get; set; }
        int Level { get; set; }
        int Attack { get; set; }
        int Defense { get; set; }
        Race Race { get; set; }
    }
}
