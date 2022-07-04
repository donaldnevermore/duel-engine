import React from "react"
import { Grid } from "@mui/material"

import { Field } from "../Field/Field"
import { Hand } from "../Hand/Hand"
import { generateDeck } from "../../lib/util"
import { Duel } from "../../lib/duel"
import { Player } from "../../lib/player"
import styles from "./Screen.module.css"

// Can't use absolute path in Screen component.

export const Screen = () =>  {
    const duel = new Duel()
    const p1 = new Player(generateDeck())
    const p2 = new Player(generateDeck())

    duel.addPlayers(p1, p2)
    duel.initialize()

    return (
        <Grid container className={styles.container}>
            <Grid item xs={2}></Grid>
            <Grid item xs={8}>
                <Hand player={p2}></Hand>
                <Field duel={duel}></Field>
                <Hand player={p1}></Hand>
            </Grid>
            <Grid item xs={2}></Grid>
        </Grid>
    )
}
