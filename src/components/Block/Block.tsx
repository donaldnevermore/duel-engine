import React from "react"
import styles from "./Block.module.css"
import { Card } from "../Card/Card"

export function Block() {
    return (
        <div className={styles.block}>
            <Card></Card>
        </div>
    )
}
