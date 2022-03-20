// Copyright (c) 2020 donaldnevermore
// All rights reserved.
// Licensed under the Apache License, Version 2.0. See the LICENSE file in the project root for more information.

import { Duel } from "./duel"
import { Player } from "./player"
import { Card } from "lib/domain/card"
import { SkyStrikerAceRaye } from "./monster-cards/sky-striker-ace-raye"
import { SkyStrikerAceRoze } from "./monster-cards/sky-striker-ace-roze"
import { Deck } from "./deck"
import { MonsterCard } from "./domain/monster-card"

const mainDeck1: Card[] = []
const mainDeck2: Card[] = []

for (let i = 0; i < 3; i++) {
    mainDeck1.push(new SkyStrikerAceRaye())
    mainDeck2.push(new SkyStrikerAceRoze())
}

const p1= new Player(new Deck(mainDeck1))
const p2= new Player(new Deck(mainDeck2))
const duel = new Duel()
duel.addPlayers(p1,p2)
duel.initialize()
p1.standbyPhase()
p1.mainPhase1()

test("start", () => {
    expect(p1.hand.length).toBe(5)
    expect(p2.hand.length).toBe(5)
})

test("summon",()=>{
    const monster = p1.hand[0] as MonsterCard
    p1.summon(monster, 0)
    expect(p1.hand.length).toBe(4)
    expect(monster).toBe(p1.monsterZone[0])
})

/*
        [Test]
        public void TestTakeTurns()
        {
            player1.TurnEnd();
            Assert.AreEqual(2, duel.Turn);

            player2.TurnEnd();
            Assert.AreEqual(3, duel.Turn);
        }

        [Test]
        public void TestHigherAttack()
        {
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
        public void TestLowerAttack()
        {
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
        public void TestMonsterEffect()
        {
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
*/
