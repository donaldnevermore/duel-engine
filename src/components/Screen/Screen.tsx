import React from "react"
import { Grid, Stack } from "@mui/material"
import { Field } from "../Field/Field"

export class Screen extends React.Component {
    /**
     * render
     */
    public render() {
        return (
            <Grid container>
                <Grid item xs={2}></Grid>
                <Grid item xs={8}>
                    <Field></Field>
                </Grid>
                <Grid item xs={2}></Grid>
            </Grid>
        )
    }
}
