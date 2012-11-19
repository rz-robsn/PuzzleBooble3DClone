# PuzzleBooble3dClone #

A 3d Version of the puzzle booble game in XNA.

### Feature list : ###

- 1 Leveled-game 
- Ball Animations when they "Pop", "Load", "Fall" or "Roll"

## Run Instructions ##

- Unzip the package
- Open the PuzzleBoobleClone.sln file with Visual Studio
- Go to Debug -> Start Without Debugging

## Known Issues ##

- Sometimes the ball falls even if it is attached to another ball.

## Code Comments ##

- Used elements inheriting from Microsoft.Xna.Framework.GameComponent and Microsoft.Xna.Framework.DrawableGameComponents to provide a modular way of adding functionality to the game.
- BallGrid.cs holds all the Balls that are present on the balls grid and contain all the game logic and rules.
- ComponentController.cs holds the current ball fired, the next ball to be fired, and triggers interaction with HangingBalls.
- FieldBounds.cs tracks the current upper wall limit that goes down every 15 seconds.
- BallAnimationHelper manages a Ball.cs state and determines what sprite to draw depending on the that state.