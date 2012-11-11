using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PuzzleBooble3DClone.GameComponents
{
    public class GameComponentManager : PuzzleBoobleGameComponent
    {
        public Camera Camera;
        public Floor floor;
        public Ball ball;

        public GameComponentManager(PuzzleBooble3dGame puzzleGame) : base(puzzleGame) 
        {
            Camera = new Camera(PuzzleBooble3dGame);
            Floor floor = new Floor(PuzzleBooble3dGame);
            Ball ball = new Ball(PuzzleBooble3dGame, floor.GetTopLeftPosition() + new Vector3(Ball.BALL_RADIUS, Ball.BALL_RADIUS, Ball.BALL_RADIUS));

            PuzzleBooble3dGame.Components.Add(Camera);
            PuzzleBooble3dGame.Components.Add(floor);
            PuzzleBooble3dGame.Components.Add(ball);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
