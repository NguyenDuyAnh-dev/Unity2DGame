# Lab 1: 2D Unity Game – Space Explorer

## Unity Version
6000.0.32f1

## A. Game Concept
Space Explorer is a 2D space-themed game where the player controls a spaceship, navigating through space while avoiding asteroids and collecting stars to enhance their shooting ability.

## B. Game Elements
### 1. Spaceship (Player)
#### 1.1 Description
A 2D spaceship that the player controls.

#### 1.2 Functionality
- Change the spaceship type using the right mouse button.
- Move in all directions using the arrow keys.
- Shoot fireballs to destroy obstacles using the left mouse button.
- **Form 1:** Shoot red fireballs.
- **Form 2:** Shoot blue fireballs.
- Collect Balls to upgrade fireballs.

#### Fireball Levels
| Level | Fireball Size | Speed | Damage |
|--------|--------------|------|--------|
| Level 1 | Small | 3 | 1 |
| Level 2 | Medium | 4 | 1.5 |
| Level 3 | Big | 5 | 2 |
| Level 4 | Huge | 5 | 3 |

### 2. Asteroids
#### 2.1 Description
Floating 2D asteroids appearing randomly in space.

#### 2.2 Functionality
- Asteroids have 5 types with different HP:
  - **Type 1 - Type 4:** Random HP from 3 - 6.
  - **Type 5:** HP = 7.
- Asteroids explode when destroyed by a bullet.
- Creating challenges for the player.
- If an asteroid collides with the spaceship, the game will end.
- Move unpredictably within the scene.

### 3. Balls (Item Drop)
#### 3.1 Description
Collectible 2D balls scattered throughout space. Spawn every 30s. Comes in two forms, blue and red.

#### 3.2 Functionality
- Increase the player's shooting power when collected.
- Enhance the gameplay experience by rewarding exploration.

## C. Game Flow
### 1. Main Menu Scene
- **Play Button:** Starts the game and transitions to the Gameplay Scene.
- **Exit Button:** Closes the game.

### 2. Gameplay Scene
#### 2.1 Game Elements
- Spaceship (player).
- Asteroids (obstacles).
- Balls (collectibles).

#### 2.2 Objective
- Navigate the spaceship while avoiding asteroids.
- Collect balls to improve shooting abilities.
- The game ends when the spaceship collides with an asteroid.

#### 2.3 UI Elements
- Score display to track the player's progress.

### 3. End Game Scene
- Displays the player's final score.
- Provides options to:
  - **Return to Main Menu:** Restart the game.
  - **Quit the Game:** Exit the application.
