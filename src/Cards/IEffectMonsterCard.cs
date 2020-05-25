namespace DuelEngine.Cards {
    public interface IEffectMonsterCard : IMonsterCard {
        void Effect(Player controller, Player opponent);
        bool CanActivate(Player controller, Player opponent);
    }
}
