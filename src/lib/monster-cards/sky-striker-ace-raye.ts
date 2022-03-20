import { EffectMonsterCard } from "lib/domain/effect-monster-card"
import { Attribute } from "lib/domain/attribute"
import { MonsterType } from "lib/domain/monster-type"

export class SkyStrikerAceRaye implements EffectMonsterCard {
    public name = "闪刀姬-零衣"
    public code = "26077387"
    public text =
        "这个卡名的①②的效果1回合各能使用1次。\
①：把这张卡解放才能发动。从额外卡组把1只「闪刀姬」怪兽在额外怪兽区域特殊召唤。这个效果在对方回合也能发动。\
②：这张卡在墓地存在的状态，自己场上的表侧表示的「闪刀姬」连接怪兽因对方的效果从场上离开的场合或者被战斗破坏的场合才能发动。这张卡特殊召唤。"
    public attribute = Attribute.Dark
    public level = 4
    public attack = 1500
    public defense = 1500
    public monsterType = MonsterType.Warrior

    /*
        public  Effect( controller Player, Player opponent) {
            // TODO: reimplement this method
            var duel = controller.Duel;
            if (duel.Phase != Phase.Main) {
                return;
            }

            if (!CanActivate(controller, opponent)) {
                throw new Exception("Condition and cost don't satisfy.");
            }

            controller.SelectMonsterEvent += (sender, e) => { controller.Draw(1); };
        }

        public bool CanActivate(Player controller, Player opponent) {
            return EffectCondition(controller, opponent) && EffectCost(controller, opponent);
        }

        private bool EffectCondition(Player controller, Player opponent) {
            return controller.Deck.Count >= 1;
        }

        private bool EffectCost(Player controller, Player opponent) {
            var monsters = controller.Hand.FindAll(card => card is MonsterCard monsterCard);
            if (monsters.Count <= 0) {
                return false;
            }

            var magicians = monsters.FindAll(card => ((MonsterCard)card).Race == Race.Magician);

            return magicians.Count > 0;
        }
        */
}
