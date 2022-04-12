import React from "react"
import { Grid, Stack } from "@mui/material"
import { Fields } from "../Fields/Fields"

export class Screen extends React.Component {
    /**
     * render
     */
    public render() {
        return (
            <Grid container>
                <Grid item xs={2}></Grid>
                <Grid item xs={8}>
                    <Fields></Fields>
                </Grid>
                <Grid item xs={2}></Grid>
            </Grid>
        )
    }
}
