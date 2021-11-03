// Copyright (c) 2020 donaldnevermore
// All rights reserved.
// Licensed under the Apache License, Version 2.0. See the LICENSE file in the project root for more information.

namespace DuelEngine {
    public class Duel {
        public Phase Phase { get; set; } = Phase.Draw;
        public int Turn { get; set; } = 1;
        public int InitialDrawNumber { get; set; } = 4;
        public int DrawLimit { get; set; } = 5;
        public int ZoneNumber { get; set; } = 3;
        public int LifePoint { get; set; } = 8000;
        public int DeckLimit { get; set; }

        public bool IsFirstTurn() {
            return Turn == 1;
        }
    }
}
