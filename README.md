# Duel engine

An open-source duel engine based on `Yu-Gi-Oh! Rush Duel`.
You can find helpful information at [https://yugipedia.com/wiki/Yu-Gi-Oh!_Rush_Duel](https://yugipedia.com/wiki/Yu-Gi-Oh!_Rush_Duel).

# Status

At a early stage.

# A simple example

```csharp
var duel = new Duel();
var player1 = new Player();
var player2 = new Player();
player1.Join(duel);
player2.Join(duel);
var monster = new MonsterCard(4, 1000, 1000);
player1.AddHandCard(monster);
player1.Summon(monster, 0);
```

# TODO

[x] Summon a monster
[x] Monster attack
[] Take turns
[] Monster effect
[] Phases
[] Field magic zone
[] Magic card & trap card

# Contribution

Please feel welcome to open a issue or pull request.
