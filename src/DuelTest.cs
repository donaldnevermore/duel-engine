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
        }

        [Test]
        public void TestSummon()
        {
            var monster = new MonsterCard(4, 1000, 1000);
            _player1.AddHandCard(monster);
            Assert.AreEqual(_player1.Hand.First(), monster);
            _player1.Summon(monster, 0);
            Assert.AreEqual(_player1.Hand.Count, 0);
            Assert.AreEqual(_player1.MonsterZone.First(), monster);
        }

        [Test]
        public void TestAttack()
        {
            var monster1 = new MonsterCard(4, 1000, 1000);
            var monster2 = new MonsterCard(4, 1500, 500);
            _player1.AddHandCard(monster1);
            _player2.AddHandCard(monster2);
            _player1.Summon(monster1, 0);
            _player1.TurnEnd();
            Assert.AreEqual(_duel.Turn, 2);
            _player2.Summon(monster2, 0);
            _player2.Attack(_player1, 0, 0);
            Assert.AreEqual(_player1.LifePoint, 7500);
            Assert.AreEqual(_player1.MonsterZone[0], null);
            Assert.AreSame(_player1.Graveyard.First(), monster1);
        }
    }
}
