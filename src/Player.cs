using System;
using System.Collections.Generic;
using System.Linq;
using DuelEngine.Cards;

namespace DuelEngine {
    public class Player {
        public List<ICard> Deck { get; set; }
        public int LifePoint { get; set; }
        public List<ICard> Hand { get; } = new List<ICard>();
        public List<ICard> Graveyard { get; } = new List<ICard>();
        public IMonster[] MonsterZone { get; set; }
        private Duel duel;

        /// <summary>
        /// Summon a monster to your monster zone.
        /// </summary>
        /// <param name="monster"></param>
        /// <param name="position"></param>
        public void Summon(IMonster monster, int position) {
            Hand.Remove(monster);
            MonsterZone[position] = monster;
        }

        /// <summary>
        /// Join in a game and initial LifePoint and MonsterZone
        /// </summary>
        /// <param name="duel"></param>
        public void Join(Duel duel) {
            this.duel = duel;
            LifePoint = duel.LifePoint;
            MonsterZone = new IMonster[duel.ZoneNumber];
        }

        public void DrawPhase() {
            duel.Phase = Phase.Draw;
        }

        public void MainPhase() {
            duel.Phase = Phase.Main;
        }

        public void BattlePhase() {
            duel.Phase = Phase.Battle;
        }

        public void EndPhase() {
            duel.Phase = Phase.End;
        }

        /// <summary>
        /// The draw before game start
        /// </summary>
        public void InitialDraw() {
            for (int i = 0; i < duel.InitialDrawNumber; i++) {
                DrawOne();
            }
        }

        /// <summary>
        /// If your hand cards is less than drawLimit, draw up to drawLimit;
        /// Else, draw 1 card.
        /// </summary>
        public void Draw() {
            if (Hand.Count < duel.DrawLimit) {
                while (Hand.Count < duel.DrawLimit) {
                    DrawOne();
                }
            }
            else {
                DrawOne();
            }
        }

        private void DrawOne() {
            var card = Deck.First();
            Deck.Remove(card);
            AddHand(card);
        }

        /// <summary>
        /// Draw a card to your hand.
        /// </summary>
        /// <param name="card">The card.</param>
        public void AddHand(ICard card) {
            Hand.Add(card);
        }

        public void TurnEnd() {
            EndPhase();
            duel.Turn++;
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
        public void Attack(Player opponent, int monsterIndex, int targetIndex) {
            IMonster monster = MonsterZone[monsterIndex];
            IMonster targetMonster = opponent.MonsterZone[targetIndex];
            int amount = monster.Attack - targetMonster.Attack;
            if (amount > 0) {
                opponent.LifePoint -= amount;
                opponent.Destroy(targetIndex);
            }
            else if (amount < 0) {
                LifePoint -= Math.Abs(amount);
                Destroy(monsterIndex);
            }
            else {
                Destroy(monsterIndex);
                opponent.Destroy(targetIndex);
            }
        }

        /// <summary>
        /// Destroy a monster and send it to your graveyard.
        /// </summary>
        /// <param name="monsterIndex"></param>
        public void Destroy(int monsterIndex) {
            IMonster monster = MonsterZone[monsterIndex];
            MonsterZone[monsterIndex] = null;
            Graveyard.Add(monster);
        }
    }
}
