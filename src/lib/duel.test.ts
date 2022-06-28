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

function setup() {
    const mainDeck1: Card[] = []
    const mainDeck2: Card[] = []

    for (let i = 0; i < 3; i++) {
        mainDeck1.push(new SkyStrikerAceRaye())
        mainDeck2.push(new SkyStrikerAceRaye())
    }
    for (let i = 0; i < 3; i++) {
        mainDeck1.push(new SkyStrikerAceRoze())
        mainDeck2.push(new SkyStrikerAceRoze())
    }

    const p1 = new Player(new Deck(mainDeck1))
    const p2 = new Player(new Deck(mainDeck2))
    const duel = new Duel()
    duel.addPlayers(p1, p2)
    duel.initialize()
    p1.standbyPhase()
    p1.mainPhase1()

    return { p1, p2, duel }
}

test("start", () => {
    const { p1, p2 } = setup()
    expect(p1.hand.length).toBe(5)
    expect(p2.hand.length).toBe(5)
})

test("summon", () => {
    const { p1 } = setup()
    const monster = p1.hand[0] as MonsterCard
    p1.summon(0, 0)
    expect(p1.hand.length).toBe(4)
    expect(monster).toBe(p1.monsterZone[0])
})

test("take turns", () => {
    const { p1, p2, duel } = setup()
    p1.turnEnd()
    expect(duel.turn).toBe(2)
    p2.turnEnd()
    expect(duel.turn).toBe(3)
})

test("should be higher attack", () => {
    const { p1, p2 } = setup()
    const monster1 = p1.hand[3] as MonsterCard
    p1.summon(3, 0)
    p1.turnEnd()

    p2.summon(0, 0)
    p2.attack(p1, 0, 0)

    expect(p1.lifePoints).toBe(7500)
    expect(p1.monsterZone[0]).toBe(undefined)
    expect(p1.graveyard[0]).toBe(monster1)
})

test("should be lower attack", () => {
    const { p1, p2 } = setup()
    p1.summon(0, 0)
    p1.turnEnd()

    const monster2 = p2.hand[3] as MonsterCard
    p2.summon(3, 0)
    p2.attack(p1, 0, 0)

    expect(p2.lifePoints).toBe(7500)
    expect(p2.monsterZone[0]).toBe(undefined)
    expect(p2.graveyard[0]).toBe(monster2)
})

/*
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
