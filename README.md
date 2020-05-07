# Duel engine

An open-source duel engine based on `Yu-Gi-Oh! Rush Duel`.
You can find helpful information at [https://yugipedia.com/wiki/Yu-Gi-Oh!_Rush_Duel](https://yugipedia.com/wiki/Yu-Gi-Oh!_Rush_Duel).

# Status

At an early stage.

# A simple example

```csharp
var duel = new Duel {InitialDrawNumber = 4, DrawLimit = 5, ZoneNumber = 3, LifePoint = 8000};

var deck1 = new List<ICard> {
                new DarkSorcerer(), new DarkSorcerer(), new DarkSorcerer(), new Wolf(), new Wolf(), new Wolf()
            };
var deck2 = new List<ICard> {
    new DarkSorcerer(), new DarkSorcerer(), new DarkSorcerer(), new Wolf(), new Wolf(), new Wolf()
};
var player1 = new Player {Deck = deck1};
var player2 = new Player {Deck = deck2};

player1.Join(duel);
player2.Join(duel);

player1.InitialDraw();
player2.InitialDraw();
player1.DrawPhase();
player1.Draw();

player1.MainPhase();
var monster = (IMonster) player1.Hand[0];
player1.Summon(monster, 0);
```

# TODO

- [x] Initial preparation
- [x] Summon a monster
- [x] Monster attack
- [ ] Take turns
- [ ] Monster effect
- [ ] Phases
- [ ] Field magic zone
- [ ] Magic card
- [ ] Trap card
- [ ] Magic & trap zone
- [ ] Field magic zone
- [ ] Draw cards
- [ ] Deck
- [ ] Graveyard

# Contribution

Please feel welcome to open a issue or pull request.
