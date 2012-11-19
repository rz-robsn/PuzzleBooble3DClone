using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Timers;

namespace PuzzleBooble3DClone.GameComponents
{
    public class ComponentController : PuzzleBoobleGameComponent
    {
        private static readonly float CURRENT_BALL_ACCELERATION = -0.007f;
        private static readonly float CURRENT_BALL_INITIAL_SPEED = 1.3f;

        public Ball CurrentBall { get; private set; }
        public Ball NextBall { get; private set; }

        private Floor Floor;
        private AimingArrow Arrow;
        private BallGrid Grid;
        private FieldBounds Bounds;

        private KeyboardState PreviousKeyState;

        private Timer ThrowBallTimer;
        private float ThrowBallTimerRemainingTime;

       public ComponentController(PuzzleBooble3dGame puzzleGame, Floor floor, AimingArrow arrow, BallGrid grid, FieldBounds bounds)
            : base(puzzleGame)
        {
            Floor = floor;
            Arrow = arrow;
            Grid = grid;
            Bounds = bounds;

            SetCurrentBall(new Ball(PuzzleBooble3dGame, GetCurrentBallPosition(), Ball.BallColor.Blue));
            SetNextBall(new Ball(PuzzleBooble3dGame, Vector3.Zero, grid.GetRandomColor())); 


            ThrowBallTimer = new Timer();
            ThrowBallTimer.AutoReset = false;
            ThrowBallTimer.Interval = 10000;
            ThrowBallTimerRemainingTime = (float)ThrowBallTimer.Interval;
            ResetTimer();
        }

        public override void Update(GameTime gameTime)
        {
            ThrowBallTimerRemainingTime = MathHelper.Clamp(ThrowBallTimerRemainingTime - (float)gameTime.ElapsedGameTime.TotalMilliseconds, 0, (float)ThrowBallTimer.Interval);

            KeyboardState state = Keyboard.GetState();
            if ((state.IsKeyDown(Keys.Space) && !PreviousKeyState.IsKeyDown(Keys.Space)
                    || state.IsKeyDown(Keys.Up) && !PreviousKeyState.IsKeyDown(Keys.Up))
                && !CurrentBall.IsMoving())
            {
                ThrowCurrentBall();
            }

            if (Bounds.BallIntersectsWithSides(CurrentBall)) 
            {
                CurrentBall.Direction.Y *= -1;
            }

            BallGrid.BallSlot interSectingSlot = Grid.BallsIntersectingWithBall(CurrentBall);
            if (CurrentBall.IsMoving() && (interSectingSlot != null || Bounds.BallIntersectsWithTop(CurrentBall)))
            {
                Grid.SetBallToNearestSlot(CurrentBall, interSectingSlot);
                SetCurrentBall(NextBall);
                SetNextBall(new Ball(PuzzleBooble3dGame, Vector3.Zero, Grid.GetRandomColor()));
            }


            if (Bounds.BallIntersectsWithTop(CurrentBall)) 
            {
                
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
            CurrentBall.Position = GetCurrentBallPosition();
            CurrentBall.Load();
        }

        private void SetNextBall(Ball ball)
        {
            NextBall = ball;
        }

        private void ThrowCurrentBall() 
        {
            ThrowBallTimerRemainingTime = (float)ThrowBallTimer.Interval;

            CurrentBall.Position = GetCurrentBallPosition();

            CurrentBall.Direction = Arrow.GetCurrentDirection();
            CurrentBall.Speed = CURRENT_BALL_INITIAL_SPEED;
            CurrentBall.Acceleration = CURRENT_BALL_ACCELERATION;

            CurrentBall.Roll();

            ThrowBallTimer.Stop();
            ResetTimer();
        }

        private void ResetTimer()
        {
            ThrowBallTimer.Elapsed += new ElapsedEventHandler(delegate(object source, ElapsedEventArgs e)
            {
                ThrowCurrentBall();
            });
            ThrowBallTimer.Start();
        }

    }
}
