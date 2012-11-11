using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PuzzleBooble3DClone.GameComponents
{
    public class Floor : PuzzleBoobleDrawableGameComponent
    {
        public static readonly float SCALE = 0.19f;
        public static readonly float WIDTH = 302 * SCALE;
        public static readonly float HEIGHT = 302 * SCALE;
        public static readonly float DEPTH = 0.25f * SCALE;

        public Model model;
        public Vector3 Position;
        public Matrix World;

        private float angle = 0;


        public Floor(PuzzleBooble3dGame game) : base(game) {}

        public override void Initialize()
        {
            base.Initialize();

            Position = new Vector3(0, 0, 0);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            model = Game.Content.Load<Model>("floor");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            angle += 0.05f;
            Position += new Vector3(0,0,0);

            World = Matrix.CreateTranslation(Position) * Matrix.CreateScale(SCALE);
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

        public Vector3 GetTopLeftPosition() 
        {
            return Position - new Vector3(WIDTH/2, HEIGHT/2, 0);
        }
    }
}
