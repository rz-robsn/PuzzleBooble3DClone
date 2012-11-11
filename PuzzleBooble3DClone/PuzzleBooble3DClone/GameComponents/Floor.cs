using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PuzzleBooble3DClone.GameComponents
{
    public class Floor : DrawableGameComponent
    {
        public static readonly float SCALE = 0.2f;
        public static readonly float WIDTH = 302 * SCALE;
        public static readonly float HEIGHT = 0.25f * SCALE;
        public static readonly float DEPTH = 302 * SCALE;

        public Model model;
        public Vector3 TopLeftPosition;
        public Matrix World;

        private Game1 game1;
        private float angle = 0;

        public Floor(Game1 game) : base(game)
        {
            game1 = (Game1)game;
        }

        public override void Initialize()
        {
            base.Initialize();

            TopLeftPosition = new Vector3(0, 0, 0);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            model = Game.Content.Load<Model>("floor-tile_30x30cm_2mm-inerside");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            angle += 0.05f;
            TopLeftPosition += new Vector3(0,0,0);

            World = Matrix.CreateTranslation(TopLeftPosition) * Matrix.CreateScale(SCALE);
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
                    effect.View = game1.View;
                    effect.Projection = game1.Projection;
                }

                mesh.Draw();
            }
        }
    }
}
