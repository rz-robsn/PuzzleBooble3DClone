using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PuzzleBooble3DClone.GameComponents
{
    public class BallGrid : PuzzleBoobleGameComponent, BoundsObserver
    {
        private static readonly int NUMBER_OF_ROWS = 10;
        private static readonly int NUMBER_OF_COLUMNS_EVEN = 12;
        private static readonly int NUMBER_OF_COLUMNS_ODD = 11;
        private static readonly float ODD_ROW_OFFSET  = Ball.BALL_RADIUS;

        public List<List<Ball>> Balls;
        private List<Ball> DeletedBalls;

        private Floor Floor;
        private FieldBounds Bounds;
        public List<HangingBallsObserver> Observer;
        private Score CurrentScore;

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


        public BallGrid(PuzzleBooble3dGame puzzleGame, Floor floor, FieldBounds bounds, Score score)
            : base(puzzleGame)
        {
            Floor = floor;
            Bounds = bounds;
            Bounds.Observer = this;
            CurrentScore = score;

            DeletedBalls = new List<Ball>();
            Observer = new List<HangingBallsObserver>();

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

        public void SetBallToNearestSlot(Ball ball, BallSlot interSectingSlot)
        {
            int nearestRowIndex;
            int nearestColumnIndex;

            List<BallSlot> emptySlots;

            if (interSectingSlot != null)
            {
                // Get the nearest empty slots.
                emptySlots = GetAllAdjacentLowerSlots(interSectingSlot);
                emptySlots.AddRange(GetAdjacentSlotsOnSameRow(interSectingSlot));
            }
            else // The ball reached the ceiling
            {
                emptySlots = GetAllTopSlots();
            }
            emptySlots.RemoveAll(slot => GetBallAtSlot(slot) != null);

            emptySlots.Sort(delegate(BallSlot slot, BallSlot otherSlot)
            {
                float length1 = (GetSlotCenter(slot) - ball.Position).Length();
                float length2 = (GetSlotCenter(otherSlot) - ball.Position).Length();
                return length1.CompareTo(length2);
            });

            if (emptySlots.Count > 0)
            {
                try
                {
                    nearestRowIndex = emptySlots.ElementAt(0).RowIndex;
                    nearestColumnIndex = emptySlots.ElementAt(0).ColumnIndex;

                    SetBallAtPosition(nearestRowIndex, nearestColumnIndex, ball);
                    DestroyAlignedPieceAtSlot(nearestRowIndex, nearestColumnIndex);

                    int numOfBallsFallen = FallDownAllBallsWithNoUpperAdjacentBalls(nearestRowIndex, nearestColumnIndex);
                    CurrentScore.Value += (numOfBallsFallen > 0) ? (int)Math.Pow(2, numOfBallsFallen) * 10
                                                                 : 0;
                    CheckIfPlayerWins();
                    CheckIfPlayerLost();            
                }
                catch (SlotOccupiedException ex)
                {
                }
            }
            else
            {
                //Set All balls to Dark
                foreach (List<Ball> list in Balls)
                {
                    foreach (Ball b in list)
                    {
                        if (b != null)
                        {
                            b.GoDark();
                        }
                    }
                }

                Observer.ForEach(observer => observer.OnPlayerLoses());
            }
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
                return Floor.TopLeftPosition + new Vector3(Ball.BALL_RADIUS, Ball.BALL_RADIUS, Ball.BALL_RADIUS);
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

        public void OnOneRowRemoved(FieldBounds bound)
        {
            // Reposition All Rows
            for (int i = 0; i < NUMBER_OF_ROWS; i++)
            {
                for (int j = 0; j < GetNumberOfColumnForRow(i); j++)
                {
                    Ball ball = GetBallAtSlot(i, j);
                    if (ball != null)
                    {
                        RefreshBallPosition(i, j, ball);
                    }
                }
            }

            CheckIfPlayerLost();
        }

        public BallSlot BallsIntersectingWithBall(Ball ball)
        {
            for (int i = 0; i < NUMBER_OF_ROWS; i++)
            {
                for (int j = 0; j < GetNumberOfColumnForRow(i); j++)
                {
                    Ball b = Balls.ElementAt(i).ElementAt(j);
                    if (b != null && ball.IntersectsWithBall(b))
                    {
                        return new BallSlot(i, j);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// "Pops" the ball as well as any other ball of the same color next to it 
        /// if there are 3 or more of these balls, and updates the score.
        /// </summary>
        /// <param name="rowIndex">The RowIndex of the ball to pop.</param>
        /// <param name="columnIndex">The ColumnIndex of the ball to pop.</param>
        private void DestroyAlignedPieceAtSlot(int rowIndex, int columnIndex)
        {
            List<BallSlot> alignedSlots = GetAllPieceOfSameColorAlignedAtSlot(rowIndex, columnIndex);

            if (alignedSlots.Count >= 3)
            {
                alignedSlots.ForEach(slot => DestroyBallAtSlot(slot));
                CurrentScore.Value += alignedSlots.Count * Score.POINTS_PER_BALLS_POPPED;
            }
        }

        private List<BallSlot> GetAllPieceOfSameColorAlignedAtSlot(int rowIndex, int columnIndex)
        {
            List<BallSlot> slots = new List<BallSlot>();
            GetAllPieceOfSameColorAlignedAtSlot(new BallSlot(rowIndex, columnIndex), GetBallAtSlot(rowIndex, columnIndex).Color, slots);
            return slots;
        }

        private void GetAllPieceOfSameColorAlignedAtSlot(BallSlot ballSlot, Ball.BallColor color, List<BallSlot> slots)
        {
            Ball ball = GetBallAtSlot(ballSlot.RowIndex, ballSlot.ColumnIndex);

            if (ball != null && ball.Color == color && !slots.Contains(ballSlot))
            {
                slots.Add(ballSlot);
                GetAllAdjacentSlots(ballSlot).ForEach(slot => GetAllPieceOfSameColorAlignedAtSlot(slot, color, slots));
            }
        }

        /// <summary>
        /// Falls all balls that have no Upper adjacent Balls.
        /// </summary>
        /// <returns>The Number of balls that fell.</returns>
        private int FallDownAllBallsWithNoUpperAdjacentBalls(int rowIndex, int columnIndex)
        {
            List<BallSlot> slots = GetAllBallsWithNoUpperAndSameRowAdjacentBalls(rowIndex, columnIndex);
            if (slots.Count > 0)
            {
                slots.ForEach(slot => FallBallAtSlot(slot));
                return slots.Count + FallDownAllBallsWithNoUpperAdjacentBalls(rowIndex, columnIndex);
            }
            return 0;
        }

        private void DestroyBallAtSlot(BallSlot slot)
        {
            Ball ball = GetBallAtSlot(slot);
            if (ball != null)
            {
                ball.Destroy();
                DeletedBalls.Add(ball);
            }
            Balls[slot.RowIndex][slot.ColumnIndex] = null;
        }

        private void FallBallAtSlot(BallSlot slot)
        {
            Ball ball = GetBallAtSlot(slot);
            if (ball != null)
            {
                ball.FallDown();
                DeletedBalls.Add(ball);
            }
            Balls[slot.RowIndex][slot.ColumnIndex] = null;
        }

        private Ball GetBallAtSlot(BallSlot slot)
        {
            return GetBallAtSlot(slot.RowIndex, slot.ColumnIndex);
        }

        private Ball GetBallAtSlot(int rowIndex, int columnIndex)
        {
            return Balls.ElementAt(rowIndex).ElementAt(columnIndex);
        }

        private List<BallSlot> GetAllBallsAdjacentToSlot(BallSlot ballSlot)
        {
            List<BallSlot> slots = new List<BallSlot>(6);

            foreach (BallSlot slot in GetAllAdjacentSlots(ballSlot))
            {
                if (GetBallAtSlot(slot) != null)
                {
                    slots.Add(slot);
                }
            }

            return slots;
        }

        private static List<BallSlot> GetAllAdjacentUpperSlots(BallSlot slot)
        {
            List<BallSlot> slots = new List<BallSlot>(6);

            if (slot.RowIndex % 2 == 0)
            {
                slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex - 1), GetClampledColumnIndex(slot.RowIndex - 1, slot.ColumnIndex - 1)));
                slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex - 1), GetClampledColumnIndex(slot.RowIndex - 1, slot.ColumnIndex)));
            }
            else
            {
                slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex - 1), GetClampledColumnIndex(slot.RowIndex - 1, slot.ColumnIndex)));
                slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex - 1), GetClampledColumnIndex(slot.RowIndex - 1, slot.ColumnIndex + 1)));
            }

            return slots;
        }

        private List<BallSlot> GetAllBallsWithNoUpperAndSameRowAdjacentBalls(int rowIndex, int columnIndex)
        {
            List<BallSlot> slots = new List<BallSlot>();

            for (int i = 1; i < NUMBER_OF_ROWS; i++)
            {
                List<BallSlot> slotListCandidate = new List<BallSlot>();
                for (int j = 0; j < GetNumberOfColumnForRow(i); j++)
                {
                    BallSlot slot = new BallSlot(i, j);

                    if ((rowIndex != i || columnIndex != j)
                        && GetBallAtSlot(slot) != null)
                    {
                        if (GetBallsForSlots(GetAllAdjacentUpperSlots(slot)).All(ball => ball == null))
                        {
                            slotListCandidate.Add(slot);
                            if (j + 1 >= GetNumberOfColumnForRow(i))
                            {
                                slots.AddRange(slotListCandidate);
                            }
                        }
                        else
                        {
                            slotListCandidate = new List<BallSlot>();
                        }
                    }
                    else if (slotListCandidate.Count > 0)
                    {
                        slots.AddRange(slotListCandidate);
                    }
                }
            }

            return slots;
        }

        private List<Ball> GetBallsForSlots(List<BallSlot> slots)
        {
            return slots.ConvertAll<Ball>(slot => GetBallAtSlot(slot));
        }

        private void RefreshBallPosition(int rowIndex, int colIndex, Ball ball)
        {
            if (rowIndex % 2 == 0)
            {
                ball.Position = Position + new Vector3(rowIndex * 2 * Ball.BALL_RADIUS, colIndex * 2 * Ball.BALL_RADIUS, 0);
            }
            else
            {
                ball.Position = Position + new Vector3(rowIndex * 2 * Ball.BALL_RADIUS, colIndex * 2 * Ball.BALL_RADIUS + ODD_ROW_OFFSET, 0); ;
            }
            ball.Normalize();
        }

        private Vector3 GetSlotCenter(BallSlot slot)
        {
            return (slot.RowIndex % 2 == 0) ? Position + new Vector3(slot.RowIndex * Ball.BALL_RADIUS*2 + Ball.BALL_RADIUS, slot.ColumnIndex * Ball.BALL_RADIUS*2 + Ball.BALL_RADIUS, Ball.BALL_RADIUS)
                                            : Position + new Vector3(slot.RowIndex * Ball.BALL_RADIUS*2 + Ball.BALL_RADIUS, ODD_ROW_OFFSET + slot.ColumnIndex * Ball.BALL_RADIUS*2 + Ball.BALL_RADIUS, Ball.BALL_RADIUS);

        }

        private void CheckIfPlayerWins()
        {
            if (Balls.All(list => list.All(ball => ball == null)))
            {
                Observer.ForEach(observer => observer.OnPlayerWins());
            }
        }

        private void CheckIfPlayerLost()
        {
            if (Balls.Any(row => row.Any(ball => ball != null && Bounds.BallReachedBottomLimit(ball))))
            {
                //Set All balls to Dark
                foreach (List<Ball> list in Balls)
                {
                    foreach (Ball ball in list)
                    {
                        if (ball != null)
                        {
                            ball.GoDark();
                        }
                    }
                }

                Observer.ForEach(observer => observer.OnPlayerLoses());
            }
        }

        private int GetCurrentLowestRowIndexLimit()
        {
            return NUMBER_OF_ROWS - Bounds.CurrentNumOfRowRemoved - 1;
        }

        private int GetLowestOccupiedRowIndex()
        {
            for (int i = NUMBER_OF_ROWS - 1; i >= 0; i--)
            {
                if (Balls[i].Any(ball => ball != null))
                {
                    return i;
                }
            }
            return 0;
        }

        private static List<BallSlot> GetAllTopSlots() 
        {
            List<BallSlot> slots = new List<BallSlot>(GetNumberOfColumnForRow(0));
            for (int i = 0; i < GetNumberOfColumnForRow(0); i++) 
            {
                slots.Add(new BallSlot(GetClampedRowIndex(0), GetClampledColumnIndex(0, i)));
            }
            return slots;
        }

        private static List<BallSlot> GetAllAdjacentLowerSlots(BallSlot slot)
        {
            List<BallSlot> slots = new List<BallSlot>(6);

            if (slot.RowIndex % 2 == 0)
            {
                slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex + 1), GetClampledColumnIndex(slot.RowIndex + 1, slot.ColumnIndex - 1)));
                slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex + 1), GetClampledColumnIndex(slot.RowIndex + 1, slot.ColumnIndex)));
            }
            else
            {
                slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex + 1), GetClampledColumnIndex(slot.RowIndex + 1, slot.ColumnIndex)));
                slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex + 1), GetClampledColumnIndex(slot.RowIndex + 1, slot.ColumnIndex + 1)));
            }

            return slots;
        }

        private static List<BallSlot> GetAdjacentSlotsOnSameRow(BallSlot slot)
        {
            List<BallSlot> slots = new List<BallSlot>(6);

            slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex), GetClampledColumnIndex(slot.RowIndex, slot.ColumnIndex - 1)));
            slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex), GetClampledColumnIndex(slot.RowIndex, slot.ColumnIndex + 1)));

            return slots;
        }

        private static List<BallSlot> GetAllAdjacentSlots(BallSlot slot)
        {
            List<BallSlot> slots = new List<BallSlot>(6);

            slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex), GetClampledColumnIndex(slot.RowIndex, slot.ColumnIndex - 1)));
            slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex), GetClampledColumnIndex(slot.RowIndex, slot.ColumnIndex + 1)));

            if (slot.RowIndex % 2 == 0)
            {
                slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex - 1), GetClampledColumnIndex(slot.RowIndex - 1, slot.ColumnIndex - 1)));
                slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex - 1), GetClampledColumnIndex(slot.RowIndex - 1, slot.ColumnIndex)));
                slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex + 1), GetClampledColumnIndex(slot.RowIndex + 1, slot.ColumnIndex - 1)));
                slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex + 1), GetClampledColumnIndex(slot.RowIndex + 1, slot.ColumnIndex)));
            }
            else
            {
                slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex - 1), GetClampledColumnIndex(slot.RowIndex - 1, slot.ColumnIndex)));
                slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex - 1), GetClampledColumnIndex(slot.RowIndex - 1, slot.ColumnIndex + 1)));
                slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex + 1), GetClampledColumnIndex(slot.RowIndex + 1, slot.ColumnIndex)));
                slots.Add(new BallSlot(GetClampedRowIndex(slot.RowIndex + 1), GetClampledColumnIndex(slot.RowIndex + 1, slot.ColumnIndex + 1)));
            }

            return slots;
        }

        private static int GetClampedRowIndex(int rowIndex)
        {
            return (int)MathHelper.Clamp(rowIndex, 0, NUMBER_OF_ROWS - 1);
        }

        private static int GetClampledColumnIndex(int rowIndex, int columnIndex)
        {
            return (int)MathHelper.Clamp(columnIndex, 0, GetNumberOfColumnForRow(rowIndex) - 1);
        }

        private static int GetNumberOfColumnForRow(int rowIndex)
        {
            return GetClampedRowIndex(rowIndex) % 2 == 0 ? NUMBER_OF_COLUMNS_EVEN : NUMBER_OF_COLUMNS_ODD;
        }


    }
}
