import React from "react"
import { Stack } from "@mui/material"
import { Block } from "../Block/Block"

export function Hand() {
    return (
        <Stack direction="row" spacing={2}>
            <Block></Block>
            <Block></Block>
            <Block></Block>
        </Stack>
    )
}
