using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Timers;

namespace PuzzleBooble3DClone.GameComponents
{
    public class FieldBounds : PuzzleBoobleGameComponent
    {
        public static float ROW_HEIGHT = 2*Ball.BALL_RADIUS;
        private static int NUMBER_OF_ROWS = 10;
        private static float BOTTOM_LIMIT_X = Floor.WIDTH * 3 / 10;

        /// <summary>
        /// The Bounds Of the Ball Field.
        /// </summary>

        public BoundsObserver Observer = null;

        private Vector2 InitialPosition = new Vector2(190, 45);
        public int CurrentNumOfRowRemoved;

        private Timer RowRemovalTimer;


        private Floor Floor;

        public FieldBounds(PuzzleBooble3dGame puzzleGame, Floor floor) : base(puzzleGame)
        {
            Floor = floor;

            CurrentNumOfRowRemoved = 0;

            RowRemovalTimer = new Timer();
            RowRemovalTimer.AutoReset = true;
            RowRemovalTimer.Interval = 15000;
            RowRemovalTimer.Elapsed += new ElapsedEventHandler(
                delegate(object source, ElapsedEventArgs e)
                {
                    RemoveOneRow();
                });
            RowRemovalTimer.Start();
        }

        public bool BallIntersectsWithSides(Ball ball) 
        {
            return Math.Abs(ball.Position.Y) > Floor.WIDTH/2;
        }

        public bool BallIntersectsWithTop(Ball ball) 
        {
            return ball.Position.X < Floor.TopLeftPosition.X - Ball.BALL_RADIUS;
        }

        public bool BallReachedBottomLimit(Ball ball) 
        {
            return ball.Position.X + Ball.BALL_RADIUS/2 > BOTTOM_LIMIT_X;
        }

        public void RemoveOneRow()
        {
            CurrentNumOfRowRemoved = (int)MathHelper.Clamp(CurrentNumOfRowRemoved + 1, 0, NUMBER_OF_ROWS);
            Floor.TopLeftPosition += new Vector3(Ball.BALL_RADIUS*2,0,0);

            if (Observer != null)
            {
                Observer.OnOneRowRemoved(this);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (CurrentNumOfRowRemoved == NUMBER_OF_ROWS)
            {
                RowRemovalTimer.Stop();
            }
        }

        public void OnPlayerWins()
        {
            RowRemovalTimer.Stop();
        }

        public void OnPlayerLoses()
        {
            RowRemovalTimer.Stop();
        }
    }
}
