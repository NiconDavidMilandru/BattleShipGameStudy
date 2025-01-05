# BattleShip Game Simulation

## Introduction

Welcome to the **BattleShip Game Simulation**! This C# application simulates the classic **BattleShip game** in a fully automated **Computer vs Computer mode**, designed to run and analyze millions of game rounds. The primary goal is to explore the strategies employed by various AI difficulty levels and gain insights into game balance and AI behavior through statistical analysis.

---

## Features

### Key Highlights:
1. **AI Difficulty Levels:**
   - **Easy Bot**: Random guessing strategy.
   - **Medium Bot**: Probability-based strategy with "hunt and target" behavior.
   - **Hard Bot**: Mix of random guessing and "hunt and target" algorithm for efficiency.
   - **Impossible Bot**: Dynamic probability recalculation after each shot.
2. **Simulation Capabilities:**
   - Simulate **1,000,000+ games** efficiently.
   - Track key performance metrics like:
     - **Win rates**
     - **Average moves to victory**
     - **Frequency of draws**
3. **Insights and Analysis:**
   - Analyze statistical trends.
   - Gain deeper insights into game balance and optimal AI tactics.

### Optimized Performance:
- The application is designed for high-performance simulations, capable of processing millions of games rapidly without compromising accuracy.

---

## Classic BattleShip Game Rules

The **BattleShip game** is a strategy-based guessing game played on a 10x10 grid. Each player strategically places their fleet of ships on the grid and takes turns guessing the location of the opponent's ships.

### Grid Layout:
- **10x10 Grid**: Each player has a grid with 100 squares.

### Ship Types and Sizes:
- **Carrier**: Occupies 5 squares.
- **Battleship**: Occupies 4 squares.
- **Cruiser**: Occupies 3 squares.
- **Submarine**: Occupies 2 squares.
- **Mine**: Occupies 1 square.

### Gameplay Rules:
1. **Ship Placement**:
   - Ships must be placed horizontally or vertically.
   - Ships cannot overlap or extend beyond the grid.
2. **Objective**:
   - Players aim to sink all opponent ships by guessing their locations on the grid.
3. **Turns**:
   - Players take turns firing shots by specifying grid coordinates (e.g., A1, B5).
   - A "hit" occurs if the shot lands on an opponent's ship.
   - A "miss" occurs if the shot lands on empty water.
4. **Victory Condition**:
   - The first player to sink all opponent ships wins.

---

## AI Algorithm Descriptions

### Easy Bot:
- **Strategy**: Random guessing.
- **Performance**: Minimal logic, making it the slowest to win (average **91 moves**).

### Medium Bot:
- **Strategy**:
  1. Calculates initial probabilities for each square based on possible ship placements.
  2. Targets the square with the highest probability.
  3. Implements a "hunt and target" approach when a ship is hit.
- **Performance**: Balanced logic with an average of **59 moves** to win.

### Hard Bot:
- **Strategy**:
  1. Starts with random guesses.
  2. Switches to a "hunt and target" mode upon hitting a ship.
- **Performance**: More efficient than Medium Bot, averaging **47 moves** to win.

### Impossible Bot:
- **Strategy**:
  1. Uses the same principles as the Medium Bot.
  2. Dynamically recalculates probabilities after each shot.
- **Performance**: The most advanced AI, winning in an average of **37 moves**.

---

## Running the Application

### Steps to Execute:
1. Launch the application.
2. Run **Computer vs Computer** mode.
3. Sit back and let the AI bots battle it out.
4. View detailed metrics and statistical analysis upon simulation completion.

### Outputs:
- **Simulation Summary**:
  - Number of games played.
  - AI win rates.
  - Average moves to victory.
  - Frequency of draws.
- **Detailed Analysis**:
  - Statistical insights into AI strategies.
  - Game balance and optimal tactics.

---

## Why Use This Simulation?

- **For Developers**: Gain insights into AI design and optimization.
- **For Researchers**: Analyze game theory and strategy development.
- **For Enthusiasts**: Explore the intricacies of the BattleShip game through a computational lens.

---

## Conclusion

This BattleShip simulation application not only recreates the fun and strategy of the classic game but also provides a platform for in-depth analysis of AI behavior and game dynamics. Dive in, run simulations, and explore the fascinating world of BattleShip strategies!
