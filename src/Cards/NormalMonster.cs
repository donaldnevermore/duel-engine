namespace DuelEngine.Cards {
    public abstract class NormalMonster : IMonster {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Text { get; set; }
        public Attribute Attribute { get; set; }
        public bool IsLegend { get; set; }
        public int Level { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public Race Race { get; set; }
    }
}
