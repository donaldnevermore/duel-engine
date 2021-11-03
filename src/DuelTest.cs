// Copyright (c) 2020 donaldnevermore
// All rights reserved.
// Licensed under the Apache License, Version 2.0. See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using NUnit.Framework;
using DuelEngine.Domain;
using DuelEngine.MonsterCards;

namespace DuelEngine {
    [TestFixture]
    public class DuelTest {
        private Duel duel;
        private Player player1;
        private Player player2;
        private List<Card> deck1;
        private List<Card> deck2;

        [SetUp]
        public void SetUp() {
            deck1 = new List<Card> {
                new DarkSorcerer(),
                new SpellArcher(),
                new MysticDealer(),

                new DarkSorcerer(),
                new DarkSorcerer(),
                new SpellArcher(),
                new SpellArcher()
            };
            deck2 = new List<Card> {
                new DarkSorcerer(),
                new SpellArcher(),
                new MysticDealer(),

                new DarkSorcerer(),
                new DarkSorcerer(),
                new SpellArcher(),
                new SpellArcher()
            };
            duel = new Duel();
            player1 = new Player { Deck = deck1 };
            player2 = new Player { Deck = deck2 };
            player1.Join(duel);
            player2.Join(duel);

            player1.InitialDraw();
            player2.InitialDraw();

            player1.DrawPhase();
            player1.Draw();
        }

        [Test]
        public void TestSummon() {
            player1.MainPhase();
            var monster = (MonsterCard)player1.Hand[0];
            player1.Summon(monster, 0);
            Assert.AreEqual(monster, player1.MonsterZone[0]);
        }

        [Test]
        public void TestTakeTurns() {
            player1.TurnEnd();
            Assert.AreEqual(2, duel.Turn);

            player2.TurnEnd();
            Assert.AreEqual(3, duel.Turn);
        }

        [Test]
        public void TestHigherAttack() {
            var monster1 = (MonsterCard)player1.Hand[1];
            player1.Summon(monster1, 0);
            player1.TurnEnd();

            var monster2 = (MonsterCard)player2.Hand[0];
            player2.Summon(monster2, 0);
            player2.Attack(player1, 0, 0);

            Assert.AreEqual(7500, player1.LifePoint);
            Assert.AreEqual(null, player1.MonsterZone[0]);
            Assert.AreSame(monster1, player1.Graveyard[0]);
        }

        [Test]
        public void TestLowerAttack() {
            var monster1 = (MonsterCard)player1.Hand[0];
            player1.Summon(monster1, 0);
            player1.TurnEnd();

            var monster2 = (MonsterCard)player2.Hand[1];
            player2.Summon(monster2, 0);
            player2.Attack(player1, 0, 0);

            Assert.AreEqual(7500, player2.LifePoint);
            Assert.AreEqual(null, player2.MonsterZone[0]);
            Assert.AreSame(monster2, player2.Graveyard[0]);
        }

        [Test]
        public void TestMonsterEffect() {
            var mysticDealer = (MonsterCard)player1.Hand[2];
            player1.Summon(mysticDealer, 0);
            // TODO:
            // player1.ActivateEffect(mysticDealer);
            // player1.SelectHandCard(2);
            // player1.HandleEffect(mysticDealer);

            Assert.AreEqual(4, player1.Hand.Count);
        }
    }
}
