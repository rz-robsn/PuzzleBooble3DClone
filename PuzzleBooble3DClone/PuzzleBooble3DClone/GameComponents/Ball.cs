using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PuzzleBooble3DClone.GameComponents
{
    public class Ball : PuzzleBoobleDrawableGameComponent
    {
        public static readonly float BALL_RADIUS = 4.67f / 2;

        public enum BallColor { Blue, Green, Red, Yellow, Orange, Purple, Silver, DarkGrey }

        public Vector3 Position;
        public float Speed;
        public Matrix World;
        public BallColor Color;
        public Model Model;

        private BallAnimationHelper AnimationHelper;
        
        public Ball(PuzzleBooble3dGame game, Vector3 position, BallColor color) : base(game) 
        {
            Color = color;
            Position = position;

            AnimationHelper = new BallAnimationHelper(this);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            Model = Game.Content.Load<Model>("Spheres/Sphere");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            World = Matrix.CreateTranslation(Position);

            AnimationHelper.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            AnimationHelper.Draw(gameTime);
        }
    }
}
