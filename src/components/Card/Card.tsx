import React, { FC } from "react"
import styles from "./Card.module.css"
import { img } from "../../lib/img"

export const Card: FC<any> = ({ card }) => {
    if (card == null) {
        return null
    }

    const url = img(card.attribute)

    return (
        <div className={styles.card}>
            <main className={styles.main}>
                <header className={styles.head}>浮幽櫻</header>
                <div className={styles.image}>
                </div>
                <div className={styles.info}>
                    <div className={styles.monster}>
                        <div className={styles.level}>
                            {card?.level}
                        </div>
                        <div className={styles.atkdef}>
                            <div className={styles.atklabel}>ATK</div>
                            <div className={styles.number}>
                                {card?.attack}
                            </div>
                            <div className={styles.deflabel}>DEF</div>
                            <div className={styles.number}>
                                {card?.defense}
                            </div>
                        </div>
                        <img src={url} className={styles.attribute} alt="" />
                    </div>
                    <div className={styles.text}>
                        {card?.text}
                    </div>
                </div>
                <footer className={styles.foot}>ⓒスタジオ·ダイス /集英社·テレビ東京·KONAMI</footer>
            </main>
        </div>
    )
}
