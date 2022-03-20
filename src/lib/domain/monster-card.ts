import { Attribute } from "./attribute"
import { MonsterType } from "./monster-type"
import { Card } from "./card"

export interface MonsterCard extends Card {
    attribute: Attribute
    level: number
    attack: number
    defense: number
    monsterType: MonsterType
}
