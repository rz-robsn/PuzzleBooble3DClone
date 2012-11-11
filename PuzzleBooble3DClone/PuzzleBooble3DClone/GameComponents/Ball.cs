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
        public Model model;

        public Vector3 Position;
        public Matrix World;

        private static readonly float BALL_RADIUS = 4.65f / 2;

        public Ball(PuzzleBooble3dGame game, Vector3 position) : base(game) 
        {
            Position = position;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            model = Game.Content.Load<Model>("UntexturedSphere");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            World = Matrix.CreateTranslation(Position);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
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
