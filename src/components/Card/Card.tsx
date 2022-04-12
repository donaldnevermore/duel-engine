import React from "react"
import styles from "./Card.module.css"

export function Card() {
    return (
        <div className={styles.card}>
            <main className={styles.main}>
                <header className={styles.head}>浮幽櫻</header>
                <div className={styles.image}>
                </div>
                <div className={styles.info}>
                    <div className={styles.text}>
                這個卡名的效果1回合只能使用1次。①：對方場上的怪獸數量比自己場上的怪獸多的場合，把這張卡從手卡丟棄才能發動。選自己的額外卡組1張卡給雙方確認。那之後，把對方的額外卡組確認，有選的卡的同名卡的場合，那些對方的同名卡全部除外。這個效果在對方回合也能發動。
                    </div>
                    <div className={styles.monster}>
                        <div className={styles.level}>3</div>
                        <div className={styles.atkdef}>
                            <div className={styles.atklabel}>ATK</div>
                            <div className={styles.number}>0</div>
                            <div className={styles.deflabel}>DEF</div>
                            <div className={styles.number}>1800</div>
                        </div>
                        <div className={styles.attribute}>
                        </div>
                    </div>
                </div>
                <footer className={styles.foot}>ⓒスタジオ·ダイス /集英社·テレビ東京·KONAMI</footer>
            </main>
        </div>
    )
}
