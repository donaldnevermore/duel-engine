import React, { Component } from "react"
import { Stack } from "@mui/material"
import { Block } from "../Block/Block"
import styles from "./Fields.module.css"

export class Field extends Component {
    public render() {
        return (
            <Stack className={styles.field} spacing={2}>
                <Stack direction="row" spacing={2}>
                    {
                        [0, 1, 2, 3, 4, 5, 6].map((i) => ( <Block key={i}></Block> ))
                    }
                </Stack>
                <Stack direction="row" spacing={2}>
                    {
                        [0, 1, 2, 3, 4, 5, 6].map((i) => ( <Block key={i}></Block> ))
                    }
                </Stack>
                <Stack direction="row" spacing={2}>
                    {
                        [0, 1, 2, 3, 4, 5, 6].map((i) => ( <Block key={i}></Block> ))
                    }
                </Stack>
                <Stack direction="row" spacing={2}>
                    {
                        [0, 1, 2, 3, 4, 5, 6].map((i) => ( <Block key={i}></Block> ))
                    }
                </Stack>
            </Stack>
        )
    }
}
