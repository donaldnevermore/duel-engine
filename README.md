# Duel engine

An open source game inspired by `Yu-Gi-Oh! Duel Monster`.

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
