

## Getting Started (CLI)

You may use **Visual Studio**, **VS Code**, or the **terminal**.

### Building the Game

1. Open a terminal in the project root directory
2. Run:
```bash
dotnet build
```

### Running the Game

From the project root:
```bash
dotnet run --project AdventureGame.Console
```

Or navigate to the console project:
```bash
cd AdventureGame.Console
dotnet run

### 🎯 Game Controls

| Key | Action |
|-----|--------|
| **W** or **↑** | Move up |
| **S** or **↓** | Move down |
| **A** or **←** | Move left |
| **D** or **→** | Move right |

## 📖 Game Rules

### Player Stats
- **Starting Health**: 100 HP
- **Maximum Health**: 150 HP (potions cannot exceed this)
- **Base Damage**: 10

### Combat System
1. Player attacks first each turn
2. Damage = Base Damage (10) + Best Weapon Modifier
3. If monster survives, it counterattacks for 10 damage
4. Battle continues until one combatant reaches 0 HP
5. **No fleeing** from battle

### Items

#### Weapons
- Automatically added to inventory when picked up
- Attack modifiers range from **3 to 10**
- **Best weapon modifier** applies to all attacks
- Inventory holds up to **100 weapons**

#### Potions
- Used **immediately** upon pickup
- Restore **20 HP** (capped at 150 HP max)
- Do not stay in inventory

### Monsters
- Health: **30-50 HP** (randomly generated)
- Damage: **10 per attack**
- Do not move or chase the player
- Spawn in random locations (5-8 per maze)

### Win/Lose Conditions

**Win**: Reach the exit tile (E)  
**Lose**: Player health drops to 0 or below

---
