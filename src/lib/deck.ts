import { Card } from "./domain/card"
import { settings } from "./domain/settings"

export class Deck {
    public constructor(public main: Card[], public extra: Card[] = [], public side: Card[] = []) {
        /*
        if (main.length > settings.maxMainDeckLength) {
            throw new Error("Invalid deck length.")
        }
        if (main.length < settings.minMainDeckLength) {
            throw new Error("Invalid deck length.")
        }
        if (extra.length > settings.maxExtraDeckLength) {
            throw new Error("Invalid deck length.")
        }
        if (side.length > settings.maxSideDeckLength) {
            throw new Error("Invalid deck length.")
        }
        */
    }
}
