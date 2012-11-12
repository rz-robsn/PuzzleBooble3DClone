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

        private Model Model;
        
        public Ball(PuzzleBooble3dGame game, Vector3 position, BallColor color) : base(game) 
        {
            Color = color;
            Position = position;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            Model = Game.Content.Load<Model>("Spheres/BlueSphere");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            World = Matrix.CreateTranslation(Position);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            foreach (ModelMesh mesh in Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.TextureEnabled = true;
                    effect.Texture = PuzzleBooble3dGame.ContentRepository.RedTexture;
                    effect.EnableDefaultLighting();
                    effect.World = World;
                    effect.View = PuzzleBooble3dGame.Camera.View;
                    effect.Projection = PuzzleBooble3dGame.Camera.Projection;
                }

                mesh.Draw();
            }
        }
    }
}
