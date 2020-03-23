using System;
using System.Collections.Generic;

namespace DuelEngine
{
    public class Player
    {
        public int LifePoint { get; set; } = 8000;
        public List<MonsterCard> Hand { get; } = new List<MonsterCard>();
        public MonsterCard[] MonsterZone { get; } = new MonsterCard[5];
        public List<MonsterCard> Graveyard { get; } = new List<MonsterCard>();
        public Duel DuelState { get; set; }

        /// <summary>
        /// Summon a monster to your monster zone
        /// </summary>
        /// <param name="monster"></param>
        /// <param name="position"></param>
        public void Summon(MonsterCard monster, int position)
        {
            Hand.Remove(monster);
            MonsterZone[position] = monster;
        }

        public void Join(Duel duel)
        {
            DuelState = duel;
        }

        /// <summary>
        /// Draw a card to your hand
        /// </summary>
        /// <param name="monster"></param>
        public void AddHandCard(MonsterCard monster)
        {
            Hand.Add(monster);
        }

        public void TurnEnd()
        {
            DuelState.Turn++;
        }

        /// <summary>
        /// Attack your opponent with your monster.
        /// if your monster's attack is higher than target monster's attack,
        /// reduce the opponent's life point by the difference and destroy the target monster.
        /// if two attacks are equal, destroy the two monsters.
        /// if your attack is lower, reduce your life point by the absolute difference, and destroy your monster.
        /// </summary>
        /// <param name="opponent"></param>
        /// <param name="monsterIndex"></param>
        /// <param name="targetIndex"></param>
        public void Attack(Player opponent, int monsterIndex, int targetIndex)
        {
            MonsterCard monster = MonsterZone[monsterIndex];
            MonsterCard targetMonster = opponent.MonsterZone[targetIndex];
            int amount = monster.Attack - targetMonster.Attack;
            if (amount > 0)
            {
                opponent.LifePoint -= amount;
                opponent.Destroy(targetIndex);
            }
            else if (amount < 0)
            {
                LifePoint -= Math.Abs(amount);
                Destroy(monsterIndex);
            }
            else
            {
                Destroy(monsterIndex);
                opponent.Destroy(targetIndex);
            }
        }

        /// <summary>
        /// Destroy a monster and send it to your graveyard
        /// </summary>
        /// <param name="monsterIndex"></param>
        public void Destroy(int monsterIndex)
        {
            MonsterCard monster = MonsterZone[monsterIndex];
            MonsterZone[monsterIndex] = null;
            Graveyard.Add(monster);
        }
    }
}
