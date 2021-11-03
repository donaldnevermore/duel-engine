// Copyright (c) 2020 donaldnevermore
// All rights reserved.
// Licensed under the Apache License, Version 2.0. See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using DuelEngine.Domain;

namespace DuelEngine {
    public class Player {
        public List<Card> Deck { get; set; }
        public int LifePoint { get; set; }
        public List<Card> Hand { get; } = new List<Card>();
        public List<Card> Graveyard { get; } = new List<Card>();
        public MonsterCard?[] MonsterZone { get; set; }
        public Duel Duel { get; set; }
        public event EventHandler SelectMonsterEvent;

        /// <summary>
        /// Summon a monster to your monster zone.
        /// </summary>
        /// <param name="monster"></param>
        /// <param name="position"></param>
        public void Summon(MonsterCard monster, int position) {
            Hand.Remove(monster);
            MonsterZone[position] = monster;
        }

        /// <summary>
        /// Join in a game and initial LifePoint and MonsterZone.
        /// </summary>
        /// <param name="duel"></param>
        public void Join(Duel duel) {
            this.Duel = duel;
            LifePoint = duel.LifePoint;
            MonsterZone = new MonsterCard[duel.ZoneNumber];
        }

        public void DrawPhase() {
            Duel.Phase = Phase.Draw;
        }

        public void MainPhase() {
            Duel.Phase = Phase.Main;
        }

        public void BattlePhase() {
            Duel.Phase = Phase.Battle;
        }

        public void EndPhase() {
            Duel.Phase = Phase.End;
        }

        /// <summary>
        /// The draw before game start.
        /// </summary>
        public void InitialDraw() {
            for (int i = 0; i < Duel.InitialDrawNumber; i++) {
                Draw(1);
            }
        }

        /// <summary>
        /// If your hand cards is less than drawLimit, draw up to drawLimit;
        /// Else, draw 1 card.
        /// </summary>
        public void Draw() {
            if (Hand.Count < Duel.DrawLimit) {
                while (Hand.Count < Duel.DrawLimit) {
                    Draw(1);
                }
            }
            else {
                Draw(1);
            }
        }

        public void Draw(int number) {
            for (int i = 0; i < number; i++) {
                var card = Deck.First();
                Deck.Remove(card);
                AddToHand(card);
            }
        }

        /// <summary>
        /// Draw a card to your hand.
        /// </summary>
        /// <param name="card">The card.</param>
        public void AddToHand(Card card) {
            Hand.Add(card);
        }

        public void TurnEnd() {
            EndPhase();
            Duel.Turn++;
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
            MonsterCard monster = MonsterZone[monsterIndex];
            MonsterCard targetMonster = opponent.MonsterZone[targetIndex];
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
            MonsterCard monster = MonsterZone[monsterIndex];
            MonsterZone[monsterIndex] = null;
            Graveyard.Add(monster);
        }

        public void SendCardFromHandToGraveyard(params Card[] cardList) {
            foreach (Card card in cardList) {
                Hand.Remove(card);
                Graveyard.Add(card);
            }

            SelectMonsterEvent?.Invoke(this, new EventArgs());
        }
    }
}
