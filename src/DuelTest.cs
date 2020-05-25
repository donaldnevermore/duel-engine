using System.Collections.Generic;
using NUnit.Framework;
using DuelEngine.Cards;
using DuelEngine.MonsterCards;

namespace DuelEngine.Test {
    [TestFixture]
    public class DuelTest {
        private Duel duel;
        private Player player1;
        private Player player2;
        private List<ICard> deck1;
        private List<ICard> deck2;

        [SetUp]
        public void SetUp() {
            deck1 = new List<ICard> {
                new DarkSorcerer(),
                new SpellArcher(),
                new MysticDealer(),

                new DarkSorcerer(),
                new DarkSorcerer(),
                new SpellArcher(),
                new SpellArcher()
            };
            deck2 = new List<ICard> {
                new DarkSorcerer(),
                new SpellArcher(),
                new MysticDealer(),

                new DarkSorcerer(),
                new DarkSorcerer(),
                new SpellArcher(),
                new SpellArcher()
            };
            duel = new Duel {InitialDrawNumber = 4, DrawLimit = 5, ZoneNumber = 3, LifePoint = 8000};
            player1 = new Player {Deck = deck1};
            player2 = new Player {Deck = deck2};
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
            var monster = (IMonsterCard) player1.Hand[0];
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
            var monster1 = (IMonsterCard) player1.Hand[1];
            player1.Summon(monster1, 0);
            player1.TurnEnd();

            var monster2 = (IMonsterCard) player2.Hand[0];
            player2.Summon(monster2, 0);
            player2.Attack(player1, 0, 0);

            Assert.AreEqual(7500, player1.LifePoint);
            Assert.AreEqual(null, player1.MonsterZone[0]);
            Assert.AreSame(monster1, player1.Graveyard[0]);
        }

        [Test]
        public void TestLowerAttack() {
            var monster1 = (IMonsterCard) player1.Hand[0];
            player1.Summon(monster1, 0);
            player1.TurnEnd();

            var monster2 = (IMonsterCard) player2.Hand[1];
            player2.Summon(monster2, 0);
            player2.Attack(player1, 0, 0);

            Assert.AreEqual(7500, player2.LifePoint);
            Assert.AreEqual(null, player2.MonsterZone[0]);
            Assert.AreSame(monster2, player2.Graveyard[0]);
        }
    }
}
