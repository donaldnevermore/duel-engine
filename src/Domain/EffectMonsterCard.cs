namespace DuelEngine.Domain {
    public interface EffectMonsterCard : MonsterCard {
        void Effect(Player controller, Player opponent);
        bool CanActivate(Player controller, Player opponent);
    }
}
