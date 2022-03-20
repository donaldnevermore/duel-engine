import React, { Component } from "react"
import {Grid, Stack} from "@mui/material"
import { Block } from "../Block/Block"
import styles from "./Fields.module.css"

export class Fields extends Component {
    public render() {
        return (
            <Grid container>
                <Grid item xs={2}></Grid>
                <Grid item xs={8}>
                    <Stack className={styles.fields} spacing={2}>
                        <Stack direction="row" spacing={2}>
                            {
                                [0,1,2,3,4,5,6].map(() => ( <Block></Block> ))
                            }
                        </Stack>
                        <Stack direction="row" spacing={2}>
                            {
                                [0,1,2,3,4,5,6].map(() => ( <Block></Block> ))
                            }
                        </Stack>
                        <Stack direction="row" spacing={2}>
                            {
                                [0,1,2,3].map(() => ( <Block></Block> ))
                            }
                        </Stack>
                        <Stack direction="row" spacing={2}>
                            {
                                [0,1,2,3,4,5,6].map(() => ( <Block></Block> ))
                            }
                        </Stack>
                        <Stack direction="row" spacing={2}>
                            {
                                [0,1,2,3,4,5,6].map(() => ( <Block></Block> ))
                            }
                        </Stack>
                    </Stack>
                </Grid>
                <Grid item xs={2}></Grid>
            </Grid>
        )
    }
}
