import React, { FC, useState, MouseEvent } from "react"
import { Box } from "@mui/material"

import styles from "./Block.module.css"
import type { Card as CardType } from "../../lib/domain/card"
import { Card } from "../Card/Card"

export const Block: FC<{
    card?: CardType
}> = ({ card }) => {
    return (
        <Box className={styles.block}>
            <Card card={card} />
        </Box>
    )
}
