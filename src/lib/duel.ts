// Copyright (c) 2020 donaldnevermore
// All rights reserved.
// Licensed under the Apache License, Version 2.0. See the LICENSE file in the project root for more information.

import { Phase } from "lib/domain/phase"
import { Player } from "./player"
import { settings } from "lib/domain/settings"

export class Duel {
    public phase = Phase.Draw
    public turn = 1

    private p1: Player|null = null
    private p2: Player|null = null

    public isFirstTurn() {
        return this.turn == 1
    }

    /**
     * Join in a game.
     */
    public addPlayers(p1: Player, p2: Player) {
        this.p1 = p1
        this.p2 = p2
    }

    /**
     * Set Life Points and draw initial cards.
     */
    public initialize() {
        this.p1!.duel = this
        this.p2!.duel = this

        this.p1!.lifePoints = settings.lifePoints
        this.p2!.lifePoints = settings.lifePoints

        this.p1!.initialDraw()
        this.p2!.initialDraw()
    }
}
