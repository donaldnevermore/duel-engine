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
                new DarkSorcerer(), new DarkSorcerer(), new DarkSorcerer(), new Wolf(), new Wolf(), new Wolf()
            };
            deck2 = new List<ICard> {
                new DarkSorcerer(), new DarkSorcerer(), new DarkSorcerer(), new Wolf(), new Wolf(), new Wolf()
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
            var monster = (IMonster) player1.Hand[0];
            player1.Summon(monster, 0);
            Assert.AreEqual(monster, player1.MonsterZone[0]);
        }

        [Test]
        public void TestHigherAttack() {
            var monster1 = (IMonster) player1.Hand[3];
            player1.Summon(monster1, 0);
            player1.TurnEnd();
            Assert.AreEqual(2, duel.Turn);

            var monster2 = (IMonster) player2.Hand[0];
            player2.Summon(monster2, 0);
            player2.Attack(player1, 0, 0);
            Assert.AreEqual(7600, player1.LifePoint);
            Assert.AreEqual(null, player1.MonsterZone[0]);
            Assert.AreSame(monster1, player1.Graveyard[0]);
        }

        [Test]
        public void TestLowerAttack() {
            var monster1 = (IMonster) player1.Hand[0];
            player1.AddHand(monster1);
            var monster2 = (IMonster) player2.Hand[3];
            player2.AddHand(monster2);

            player1.Summon(monster1, 0);
            player1.TurnEnd();

            player2.Summon(monster2, 0);
            player2.Attack(player1, 0, 0);
            Assert.AreEqual(7600, player2.LifePoint);
            Assert.AreEqual(null, player2.MonsterZone[0]);
            Assert.AreSame(monster2, player2.Graveyard[0]);
        }
    }
}
