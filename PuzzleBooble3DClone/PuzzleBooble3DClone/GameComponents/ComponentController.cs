using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PuzzleBooble3DClone.GameComponents
{
    public class ComponentController : PuzzleBoobleGameComponent
    {
        public Ball CurrentBall { get; private set; }
        public Ball NextBall { get; private set; }

        private Floor Floor;
        private AimingArrow Arrow;
        private BallGrid Grid;

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

    }
}
