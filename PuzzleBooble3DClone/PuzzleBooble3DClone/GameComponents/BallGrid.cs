using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PuzzleBooble3DClone.GameComponents
{
    public class BallGrid : PuzzleBoobleGameComponent
    {
        private static readonly int NUMBER_OF_ROWS = 10;
        private static readonly int NUMBER_OF_COLUMNS_EVEN = 12;
        private static readonly int NUMBER_OF_COLUMNS_ODD = 11;
        private static readonly Vector3 ODD_ROW_OFFSET = new Vector3(0, Ball.BALL_RADIUS, 0);

        public List<List<Ball>> Balls;

        private Floor Floor;

        public BallGrid(PuzzleBooble3dGame puzzleGame, Floor floor) : base(puzzleGame) 
        {
            Floor = floor;

            Balls = new List<List<Ball>>(NUMBER_OF_ROWS);
            for (int i = 0; i < NUMBER_OF_ROWS; i++)
            {
                Balls.Insert(i, new List<Ball>(i % 2 == 0 ? NUMBER_OF_COLUMNS_EVEN : NUMBER_OF_COLUMNS_ODD));
                if (i % 2 == 0)
                {
                    for (int j = 0; j < NUMBER_OF_COLUMNS_EVEN; j++)
                    {
                        Balls.ElementAt(i).Add(null);
                    }
                }
                else
                {
                    for (int j = 0; j < NUMBER_OF_COLUMNS_ODD; j++)
                    {
                        Balls.ElementAt(i).Add(null);
                    }
                }
            }

                SetNewBallAtPosition(0, 0, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Red));
                SetNewBallAtPosition(0, 1, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Red));
                SetNewBallAtPosition(0, 2, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Yellow));
                SetNewBallAtPosition(0, 3, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Yellow));
                SetNewBallAtPosition(0, 4, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Blue));
                SetNewBallAtPosition(0, 5, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Blue));
                SetNewBallAtPosition(0, 6, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Green));
                SetNewBallAtPosition(0, 7, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Green));
                SetNewBallAtPosition(1, 0, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Red));
                SetNewBallAtPosition(1, 1, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Red));
                SetNewBallAtPosition(1, 2, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Yellow));
                SetNewBallAtPosition(1, 3, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Yellow));
                SetNewBallAtPosition(1, 4, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Blue));
                SetNewBallAtPosition(1, 5, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Blue));
                SetNewBallAtPosition(1, 6, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Green));
                SetNewBallAtPosition(2, 0, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Blue));
                SetNewBallAtPosition(2, 1, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Blue));
                SetNewBallAtPosition(2, 2, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Green));
                SetNewBallAtPosition(2, 3, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Green));
                SetNewBallAtPosition(2, 4, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Red));
                SetNewBallAtPosition(2, 5, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Red));
                SetNewBallAtPosition(2, 6, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Yellow));
                SetNewBallAtPosition(2, 7, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Yellow));
                SetNewBallAtPosition(3, 0, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Blue));
                SetNewBallAtPosition(3, 1, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Green));
                SetNewBallAtPosition(3, 2, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Green));
                SetNewBallAtPosition(3, 3, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Red));
                SetNewBallAtPosition(3, 4, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Red));
                SetNewBallAtPosition(3, 5, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Yellow));
                SetNewBallAtPosition(3, 6, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Yellow));

                SetNewBallAtPosition(0, 8, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Silver));
                SetNewBallAtPosition(0, 9, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Silver));
                SetNewBallAtPosition(0, 10, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.DarkGrey));
                SetNewBallAtPosition(0, 11, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.DarkGrey));
                SetNewBallAtPosition(1, 7, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Silver));
                SetNewBallAtPosition(1, 8, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Silver));
                SetNewBallAtPosition(1, 9, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Silver));
                SetNewBallAtPosition(1, 10, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.DarkGrey));
                SetNewBallAtPosition(2, 8, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Orange));
                SetNewBallAtPosition(2, 9, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Orange));
                SetNewBallAtPosition(2, 10, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Purple));
                SetNewBallAtPosition(2, 11, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Purple));
                SetNewBallAtPosition(3, 7, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Orange));
                SetNewBallAtPosition(3, 8, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Orange));
                SetNewBallAtPosition(3, 9, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Purple));
                SetNewBallAtPosition(3, 10, new Ball(PuzzleBooble3dGame, Vector3.Zero, Ball.BallColor.Purple));
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void SetNewBallAtPosition(int rowIndex, int colIndex, Ball ball) 
        {
            PuzzleBooble3dGame.Components.Add(ball);
            this.SetBallAtPosition(rowIndex, colIndex, ball);
        }

        public void SetBallAtPosition(int rowIndex, int colIndex, Ball ball)
        {
            if (Balls.ElementAt(rowIndex).ElementAt(colIndex) != null)
            {
                throw new SlotOccupiedException(rowIndex, colIndex);
            }
            Balls[rowIndex][colIndex] = ball;

            RefreshBallPosition(rowIndex, colIndex, ball);
        }

        public Vector3 Position
        {
            get
            {
                return Floor.GetTopLeftPosition() + new Vector3(Ball.BALL_RADIUS, Ball.BALL_RADIUS, Ball.BALL_RADIUS);
            }
        }

        public Ball.BallColor GetRandomColor()
        {
            // Pick One color out of those in the grid.
            IEnumerable<Ball> BallPool = Balls.SelectMany(list => list).Where(ball => ball != null);

            if (BallPool.Count() > 0)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, BallPool.Count());
                return BallPool.ElementAt(randomNumber).Color;
            }
            else
            {
                return Ball.BallColor.Blue;
            }
        }

        private void RefreshBallPosition(int rowIndex, int colIndex, Ball ball)
        {
            if (rowIndex % 2 == 0)
            {
                ball.Position = Position + new Vector3(rowIndex * 2*Ball.BALL_RADIUS, colIndex * 2*Ball.BALL_RADIUS, 0);
            }
            else
            {
                ball.Position = Position + ODD_ROW_OFFSET + new Vector3(rowIndex * 2 * Ball.BALL_RADIUS, colIndex * 2 * Ball.BALL_RADIUS, 0); ;
            }
            ball.Speed = 0;
        }

        /// <summary>
        /// Represents a Slot in the Ball Field
        /// </summary>
        public class BallSlot
        {
            public int RowIndex;
            public int ColumnIndex;

            public BallSlot(int rowIndex, int columnIndex)
            {
                RowIndex = rowIndex;
                ColumnIndex = columnIndex;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is BallSlot))
                {
                    return false;
                }
                else
                {
                    return this.Equals((BallSlot)obj);
                }
            }

            public bool Equals(BallSlot otherSlot)
            {
                return RowIndex == otherSlot.RowIndex && ColumnIndex == otherSlot.ColumnIndex;
            }

            public override string ToString()
            {
                return "Slot(" + RowIndex + "," + ColumnIndex + ")";
            }
        }

        public class SlotOccupiedException : Exception
        {
            public int RowIndex;
            public int ColumnIndex;

            public SlotOccupiedException(int rowIndex, int columnIndex)
                : base(String.Format("There is already a ball at Slot ({0},{1})",
                            rowIndex.ToString(), columnIndex.ToString()))
            {
                RowIndex = rowIndex;
                ColumnIndex = columnIndex;
            }
        }
    }
}
