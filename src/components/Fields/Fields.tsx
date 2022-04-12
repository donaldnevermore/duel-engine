import React from "react"
import { Stack } from "@mui/material"
import { Block } from "../Block/Block"
import styles from "./Fields.module.css"

export class Fields extends React.Component {
    public render() {
        return (
            <Stack className={styles.fields} spacing={2}>
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
