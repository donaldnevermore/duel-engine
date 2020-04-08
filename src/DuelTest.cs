using NUnit.Framework;
using System.Linq;

namespace DuelEngine.Test
{
    [TestFixture]
    public class DuelTest
    {
        private Duel _duel;
        private Player _player1;
        private Player _player2;

        [SetUp]
        public void SetUp()
        {
            _duel = new Duel();
            _player1 = new Player();
            _player2 = new Player();
            _player1.Join(_duel);
            _player2.Join(_duel);
            _player1.InitialDraw();
            _player2.InitialDraw();
            _player1.DrawPhase();
            _player1.Draw();
        }

        [Test]
        public void TestSummon()
        {
            _player1.MainPhase();
            var monster = new MonsterCard(4, 1000, 1000);
            _player1.AddHandCard(monster);
            _player1.Summon(monster, 0);
            Assert.AreEqual(monster, _player1.MonsterZone.First());
        }

        [Test]
        public void TestHigherAttack()
        {
            var monster1 = new MonsterCard(4, 1000, 1000);
            _player1.AddHandCard(monster1);
            var monster2 = new MonsterCard(4, 1500, 500);
            _player2.AddHandCard(monster2);

            _player1.Summon(monster1, 0);
            _player1.TurnEnd();
            Assert.AreEqual(2, _duel.Turn);

            _player2.Summon(monster2, 0);
            _player2.Attack(_player1, 0, 0);
            Assert.AreEqual(7500, _player1.LifePoint);
            Assert.AreEqual(null, _player1.MonsterZone[0]);
            Assert.AreSame(monster1, _player1.Graveyard.First());
        }

        [Test]
        public void TestLowerAttack()
        {
            var monster1 = new MonsterCard(4, 1500, 500);
            _player1.AddHandCard(monster1);
            var monster2 = new MonsterCard(4, 1000, 1000);
            _player2.AddHandCard(monster2);

            _player1.Summon(monster1, 0);
            _player1.TurnEnd();
            Assert.AreEqual(_duel.Turn, 2);

            _player2.Summon(monster2, 0);
            _player2.Attack(_player1, 0, 0);
            Assert.AreEqual(7500, _player2.LifePoint);
            Assert.AreEqual(null, _player2.MonsterZone[0]);
            Assert.AreSame(monster2, _player2.Graveyard.First());
        }
    }
}
