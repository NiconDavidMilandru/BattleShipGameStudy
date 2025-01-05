# 🎮 BattleShip Game Simulation

## 🚀 Introduction

Welcome to the **BattleShip Game Simulation**! This C# application simulates the classic **BattleShip game** in a fully automated **Computer vs Computer mode**. 

The primary goal is to:
- 🧠 Explore strategies employed by various AI difficulty levels.
- 📊 Gain insights into game balance and AI behavior through statistical analysis.

---

## 🌟 Features

### 🔑 Key Highlights:
1. **Four AI Difficulty Levels**:
   - 🟢 **Easy Bot**: Random guessing strategy.
   - 🟡 **Medium Bot**: Probability-based strategy with "hunt and target" behavior.
   - 🔵 **Hard Bot**: Mix of random guessing and "hunt and target" for efficiency.
   - 🔴 **Impossible Bot**: Dynamic probability recalculation after each shot.

2. **⚡ Simulation Capabilities**:
   - Simulate **1,000,000+ games** with high performance.
   - Track key performance metrics like:
     - 🏆 **Win rates**
     - ⏱️ **Average moves to victory**
     - 🤝 **Frequency of draws**

3. **🔍 Insights and Analysis**:
   - Analyze **statistical trends**.
   - Gain deeper insights into **game balance** and **optimal AI tactics**.

---

## 📜 Classic BattleShip Game Rules

The **BattleShip game** is a strategy-based guessing game played on a **10x10 grid**.

### 🎯 Objective:
- Sink all the opponent’s ships before they sink yours!

### 🗺️ Grid Layout:
- **10x10 Grid**: Each player has 100 squares.

### 🚢 Ship Types and Sizes:
| Ship Type   | Size (Squares) |
|-------------|----------------|
| **Carrier** | 5              |
| **Battleship** | 4          |
| **Cruiser** | 3              |
| **Submarine** | 2            |
| **Mine**     | 1            |

### ⚔️ Gameplay Rules:
1. **Ship Placement**:
   - Ships must be placed **horizontally** or **vertically**.
   - Ships cannot **overlap** or extend beyond the grid.
2. **Turns**:
   - Players fire shots by specifying grid coordinates (e.g., `A1`, `B5`).
   - A **hit** occurs when a shot lands on an opponent's ship.
   - A **miss** occurs when a shot lands on empty water.
3. **Victory Condition**:
   - The first player to sink all opponent ships **wins**.

---

## 🤖 AI Algorithm Descriptions

### 🟢 Easy Bot:
- **Strategy**: Random guessing.
- **Performance**: Simple but slow, with an average of **91 moves** to win.

### 🟡 Medium Bot:
- **Strategy**:
  1. Calculates **initial probabilities** for each square.
  2. Targets the square with the **highest probability**.
  3. Uses a "hunt and target" approach to sink ships.
- **Performance**: Balanced logic with an average of **59 moves** to win.

### 🔵 Hard Bot:
- **Strategy**:
  1. Shoots **randomly** until a ship is hit.
  2. Switches to a **"hunt and target" mode** to sink the ship.
- **Performance**: Faster than the Medium Bot, with an average of **47 moves** to win.

### 🔴 Impossible Bot:
- **Strategy**:
  1. Similar to the Medium Bot.
  2. Dynamically recalculates probabilities **after each shot**.
- **Performance**: The most advanced AI, winning in an average of **37 moves**.

---

## 🛠️ Running the Application

### Steps to Execute:
1. Launch the application.
2. Select **Computer vs Computer Mode**.
3. Watch the AI bots battle it out!
4. View detailed metrics and statistical insights after the simulation.

### 📊 Outputs:
- **Simulation Summary**:
  - Number of games played.
  - AI win rates.
  - Average moves to victory.
  - Frequency of draws.
- **Detailed Analysis**:
  - Statistical trends and insights into AI strategies.
  - Evaluation of game balance and AI performance.

---

## 🤔 Why Use This Simulation?

- **For Developers**: Explore and refine AI design.
- **For Researchers**: Study game theory and optimal strategies.
- **For Enthusiasts**: Enjoy a deep dive into the mechanics of the classic BattleShip game.

---

## 🎉 Conclusion

The **BattleShip Game Simulation** is more than just a game—it’s a powerful tool for analyzing strategies, refining AI behavior, and exploring the balance of one of the most beloved games of all time.

- 🕹️ Dive in.
- 🧠 Learn from the AI.
- 🚢 Master the BattleShip battlefield!

**Enjoy strategizing and exploring the world of BattleShip!**
