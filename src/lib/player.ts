// Copyright (c) 2020 donaldnevermore
// All rights reserved.
// Licensed under the Apache License, Version 2.0. See the LICENSE file in the project root for more information.

import { Card } from "./domain/card"
import { MonsterCard } from "lib/domain/monster-card"
import { Duel } from "./duel"
import { Phase } from "./domain/phase"
import { settings } from "./domain/settings"
import { Deck } from "./deck"

export class Player {
    public lifePoints = 0
    public hand: Card[] = []
    public graveyard: Card[] = []
    public monsterZone: (MonsterCard | undefined)[] = []
    public duel: Duel | null = null

    public constructor(public deck: Deck) {
    }

    /**
     * Summon a monster from your hand to the monster zone.
     */
    public summon(index: number, position: number) {
        const monster = this.hand[index] as MonsterCard
        this.monsterZone[position] = monster
        this.hand.splice(index, 1)
    }

    public drawPhase() {
        this.duel!.phase = Phase.Draw
    }

    public standbyPhase() {
        this.duel!.phase = Phase.Standby
    }

    public mainPhase1() {
        this.duel!.phase = Phase.Main1
    }

    public battlePhase() {
        this.duel!.phase = Phase.Battle
    }

    public endPhase() {
        this.duel!.phase = Phase.End
    }

    /**
     * The draw before game start.
     */
    public initialDraw() {
        for (let i = 0; i < settings.initialDrawNumber; i++) {
            this.draw(1)
        }
    }

    /**
     * Draw some cards.
     */
    public draw(n: number) {
        for (let i = 0; i < n; i++) {
            const card = this.deck.main.shift()
            if (card === undefined) {
                throw new Error("No cards")
            }
            this.addToHand(card)
        }
    }

    /**
     * Draw a card to your hand.
     */
    public addToHand(card: Card) {
        this.hand.push(card)
    }

    public turnEnd() {
        this.endPhase()
        this.duel!.turn++
    }

    /**
     * Attack your opponent with your monster.
     * if your monster's attack is higher than target monster's attack,
     * reduce the opponent's life point by the difference and destroy the target monster.
     * if two attacks are equal, destroy the two monsters.
     * if your attack is lower, reduce your life point by the absolute difference, and destroy your monster.
     */
    public attack(opponent: Player, monsterIndex: number, targetIndex: number) {
        const monster = this.monsterZone[monsterIndex]
        if (monster === undefined) {
            throw new Error("No such a monster card")
        }
        const targetMonster = opponent.monsterZone[targetIndex] as MonsterCard
        const amount = monster.attack - targetMonster.attack
        if (amount > 0) {
            opponent.lifePoints -= amount
            opponent.destroy(targetIndex)
        }
        else if (amount < 0) {
            this.lifePoints -= Math.abs(amount)
            this.destroy(monsterIndex)
        }
        else {
            this.destroy(monsterIndex)
            opponent.destroy(targetIndex)
        }
    }

    /**
     * Destroy a monster and send it to your graveyard.
     */
    public destroy(monsterIndex: number) {
        const monster = this.monsterZone[monsterIndex]
        if (monster === undefined) {
            throw new Error("No such a monster card")
        }
        this.monsterZone[monsterIndex] = undefined
        this.graveyard.push(monster)
    }

    public sendCardFromHandToGraveyard(...cardList: Card[]) {
        for (const card of cardList) {
            const idx = this.hand.indexOf(card)
            this.hand.splice(idx, 1)
            this.graveyard.push(card)
        }
    }
}
