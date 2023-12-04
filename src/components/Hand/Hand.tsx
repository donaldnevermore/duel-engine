import React, { FC, useState, MouseEvent } from "react"
import { Popper, Box, Button } from "@mui/material"
import { Stack } from "@mui/material"
import { Player } from "../../lib/player"
import { Card } from "../Card/Card"
import styles from "./Hand.module.css"

export const Hand: FC<{
    player: Player
}> = ({ player }) => {
    return (
        <Stack direction="row">
            {player.hand.map((card: any, i: number) => <CardContainer card={card} key={i} />)}
        </Stack>
    )
}

const CardContainer: FC<any> = ({ card }) => {
    const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null)

    const handleOpen = (event: MouseEvent<HTMLElement>) => {
        setAnchorEl(event.currentTarget)
    }

    const handleClose = () => {
        setAnchorEl(null)
    }

    const summon = () => {
        console.log("summon")
    }

    const open = Boolean(anchorEl)

    return (
        <Box className={styles.container} onMouseEnter={handleOpen} onMouseLeave={handleClose}>
            <Popper open={open} placement="top" anchorEl={anchorEl}>
                <Button onClick={summon}>召唤</Button>
                <Button>盖放</Button>
            </Popper>

            <Box>
                <Card card={card} />
            </Box>
        </Box>
    )
}
