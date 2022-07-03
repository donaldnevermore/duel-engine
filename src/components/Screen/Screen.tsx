import React, { Component } from "react"
import { Grid, Stack } from "@mui/material"
import { Field } from "../Field/Field"
import { Hand } from "../Hand/Hand"

// Can't use absolute path in Screen component.

export class Screen extends Component {
    /**
     * render
     */
    public render() {
        return (
            <Grid container>
                <Grid item xs={2}></Grid>
                <Grid item xs={8}>
                    <Hand></Hand>
                    <Field></Field>
                    <Hand></Hand>
                </Grid>
                <Grid item xs={2}></Grid>
            </Grid>
        )
    }
}
