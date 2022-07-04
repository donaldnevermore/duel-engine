import { Deck } from "./deck"
import { SkyStrikerAceRaye } from "./monster-cards/sky-striker-ace-raye"
import { SkyStrikerAceRoze } from "./monster-cards/sky-striker-ace-roze"

export function generateDeck(): Deck {
    return new Deck([
        new SkyStrikerAceRaye(), new SkyStrikerAceRaye(), new SkyStrikerAceRaye(),
        new SkyStrikerAceRoze(), new SkyStrikerAceRoze()
    ], [], [])
}
