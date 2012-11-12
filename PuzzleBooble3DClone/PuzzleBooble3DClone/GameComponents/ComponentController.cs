using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PuzzleBooble3DClone.GameComponents
{
    public class ComponentController : PuzzleBoobleGameComponent
    {
        private static readonly float CURRENT_BALL_ACCELERATION = -0f;
        private static readonly float CURRENT_BALL_INITIAL_SPEED = 1f;

        public Ball CurrentBall { get; private set; }
        public Ball NextBall { get; private set; }

        private Floor Floor;
        private AimingArrow Arrow;
        private BallGrid Grid;

        private KeyboardState PreviousKeyState;

       public ComponentController(PuzzleBooble3dGame puzzleGame, Floor floor, AimingArrow arrow, BallGrid grid)
            : base(puzzleGame)
        {
            Floor = floor;
            Arrow = arrow;
            Grid = grid;


            SetCurrentBall(new Ball(PuzzleBooble3dGame, GetCurrentBallPosition(), Ball.BallColor.Blue));

        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if ((state.IsKeyDown(Keys.Space) && !PreviousKeyState.IsKeyDown(Keys.Space)
                    || state.IsKeyDown(Keys.Up) && !PreviousKeyState.IsKeyDown(Keys.Up))
                && !CurrentBall.IsMoving())
            {
                ThrowCurrentBall();
            }
        }

        public Vector3 GetCurrentBallPosition() 
        {
            return Arrow.Position;
        }

        private void SetCurrentBall(Ball ball)
        {
            if(!PuzzleBooble3dGame.Components.Contains(ball))
            {
                PuzzleBooble3dGame.Components.Add(ball);
            }

            CurrentBall = ball;
            ball.Position = GetCurrentBallPosition();
        }

        private void ThrowCurrentBall() 
        {
            CurrentBall.Position = GetCurrentBallPosition();

            CurrentBall.Direction = Arrow.GetCurrentDirection();
            CurrentBall.Speed = CURRENT_BALL_INITIAL_SPEED;
        }

    }
}
