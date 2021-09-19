using System;
using System.Collections.Generic;
using DuelEngine.Domain;

namespace DuelEngine.MonsterCards {
    public class MysticDealer : EffectMonsterCard {
        public string Name { get; set; } = "Mystic Dealer";
        public string Id { get; set; } = "120105006";
        public string Text { get; set; } = "hhh";
        public Domain.Attribute Attribute { get; set; } = Domain.Attribute.Water;
        public bool IsLegend { get; set; } = false;
        public int Level { get; set; } = 3;
        public int Attack { get; set; } = 1000;
        public int Defense { get; set; } = 0;
        public Race Race { get; set; } = Race.Magician;

        public void Effect(Player controller, Player opponent) {
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
    }
}
