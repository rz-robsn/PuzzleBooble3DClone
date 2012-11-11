using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PuzzleBooble3DClone.GameComponents
{
    public class BallGrid : PuzzleBoobleGameComponent
    {
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

        private static int NUMBER_OF_ROWS = 12;
        private static int NUMBER_OF_COLUMNS_EVEN = 8;
        private static int NUMBER_OF_COLUMNS_ODD = 7;
        private static Vector3 ODD_ROW_OFFSET = new Vector3(Ball.BALL_RADIUS/2, 0, 0);

        public List<List<Ball>> Balls;

        public BallGrid(PuzzleBooble3dGame puzzleGame) : base(puzzleGame) 
        {
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

            this.SetBallAtPosition(0, 0, new Ball(PuzzleBooble3dGame, Vector3.Zero));

            PuzzleBooble3dGame.Components.Add(Balls.ElementAt(0).ElementAt(0));
        }

        public override void Initialize()
        {
            base.Initialize();

        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
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

        private void RefreshBallPosition(int rowIndex, int colIndex, Ball ball)
        {
            if (rowIndex % 2 == 0)
            {
                ball.Position = Position + new Vector3(colIndex * Ball.BALL_RADIUS, rowIndex * Ball.BALL_RADIUS, 0);
            }
            else
            {
                ball.Position = Position + ODD_ROW_OFFSET + new Vector3(colIndex * Ball.BALL_RADIUS, rowIndex * Ball.BALL_RADIUS, 0);
            }
            ball.Speed = 0;
        }

        public Vector3 Position 
        {
            get 
            {
                return PuzzleBooble3dGame.ComponentManager.floor.GetTopLeftPosition() + new Vector3(Ball.BALL_RADIUS, Ball.BALL_RADIUS, Ball.BALL_RADIUS);
            }
        }
    }
}
