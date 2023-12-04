import { MonsterCard } from "../domain/monster-card"
import type { Attribute } from "../domain/attribute"
import type { MonsterType } from "../domain/monster-type"

export class SkyStrikerAceRoze implements MonsterCard {
    public name = "闪刀姬-露世"
    public code = "37351133"
    public text =
        "这个卡名的①②的效果1回合各能使用1次。\
①：场上有「闪刀姬-露世」以外的「闪刀姬」怪兽召唤·特殊召唤的场合才能发动。这张卡从手卡特殊召唤。\
②：这张卡在墓地存在的状态，额外怪兽区域的对方怪兽被战斗破坏的场合或者因自己的卡的效果从场上离开的场合才能发动。\
这张卡特殊召唤。那之后，可以选对方场上1只表侧表示怪兽，直到回合结束时那个效果无效。"
    public attribute: Attribute = "light"
    public level = 4
    public attack = 1000
    public defense = 1000
    public monsterType: MonsterType = "warrior"
}
