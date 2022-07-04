import React, { FC } from "react"
import { Stack } from "@mui/material"
import { Block } from "../Block/Block"
import styles from "./Field.module.css"

export const Field: FC<any> = ({ duel }) => {
    return (
        <Stack className={styles.field} spacing={2}>
            <Stack direction="row" spacing={2}>
                {
                    [0, 1, 2, 3, 4, 5, 6].map((i) => <Block key={i} /> )
                }
            </Stack>

            <Stack direction="row" spacing={2}>
                {
                    [0, 1, 2, 3, 4, 5, 6].map((i) => <Block key={i} /> )
                }
            </Stack>
            <Stack direction="row" spacing={2}>
                {
                    [0, 1, 2, 3, 4, 5, 6].map((i) => <Block key={i} /> )
                }
            </Stack>
            <Stack direction="row" spacing={2}>
                {
                    [0, 1, 2, 3, 4, 5, 6].map((i) => <Block key={i} /> )
                }
            </Stack>
        </Stack>
    )
}
