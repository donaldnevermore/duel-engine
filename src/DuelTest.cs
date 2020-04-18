using NUnit.Framework;
using System.Linq;

namespace DuelEngine.Test {
    [TestFixture]
    public class DuelTest {
        private Duel duel;
        private Player player1;
        private Player player2;

        [SetUp]
        public void SetUp() {
            duel = new Duel();
            player1 = new Player();
            player2 = new Player();
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
            var monster = new MonsterCard(4, 1000, 1000);
            player1.AddHandCard(monster);
            player1.Summon(monster, 0);
            Assert.AreEqual(monster, player1.MonsterZone.First());
        }

        [Test]
        public void TestHigherAttack() {
            var monster1 = new MonsterCard(4, 1000, 1000);
            player1.AddHandCard(monster1);
            var monster2 = new MonsterCard(4, 1500, 500);
            player2.AddHandCard(monster2);

            player1.Summon(monster1, 0);
            player1.TurnEnd();
            Assert.AreEqual(2, duel.Turn);

            player2.Summon(monster2, 0);
            player2.Attack(player1, 0, 0);
            Assert.AreEqual(7500, player1.LifePoint);
            Assert.AreEqual(null, player1.MonsterZone[0]);
            Assert.AreSame(monster1, player1.Graveyard.First());
        }

        [Test]
        public void TestLowerAttack() {
            var monster1 = new MonsterCard(4, 1500, 500);
            player1.AddHandCard(monster1);
            var monster2 = new MonsterCard(4, 1000, 1000);
            player2.AddHandCard(monster2);

            player1.Summon(monster1, 0);
            player1.TurnEnd();
            Assert.AreEqual(duel.Turn, 2);

            player2.Summon(monster2, 0);
            player2.Attack(player1, 0, 0);
            Assert.AreEqual(7500, player2.LifePoint);
            Assert.AreEqual(null, player2.MonsterZone[0]);
            Assert.AreSame(monster2, player2.Graveyard.First());
        }
    }
}
