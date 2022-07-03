import React, { FC, useState, MouseEvent } from "react"
import { Popper, Box } from "@mui/material"

import styles from "./Block.module.css"
import { Card } from "../Card/Card"

export const Block: FC<{
    card?: any
}> = ({ card }) => {
    const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null)

    const handleOpen = (event: MouseEvent<HTMLElement>) => {
        setAnchorEl(event.currentTarget)
    }

    const handleClose = () => {
        setAnchorEl(null)
    }

    const open = Boolean(anchorEl)

    return (
        <div className={styles.block}>
            <Popper open={open}
                anchorEl={anchorEl}>
                <Box>sdfjlkjkljskdf</Box>
            </Popper>

            <Box onMouseEnter={handleOpen} onMouseLeave={handleClose}>
                <Card card={card} />
            </Box>
        </div>
    )
}
