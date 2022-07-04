import React, { FC } from "react"
import { Stack } from "@mui/material"
import { Block } from "../Block/Block"
import { Player } from "lib/player"

export const Hand: FC<{
    player: Player
}> = ({ player }) => {
    return (
        <Stack direction="row" spacing={2}>
            {player.hand.map((card: any, i: number) => <Block card={card} key={i} />)}
        </Stack>
    )
}
