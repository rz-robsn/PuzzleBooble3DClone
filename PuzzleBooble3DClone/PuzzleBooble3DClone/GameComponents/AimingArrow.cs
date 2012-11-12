using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PuzzleBooble3DClone.GameComponents
{
    public class AimingArrow : PuzzleBoobleDrawableGameComponent
    {
        public float WIDTH = 18.08f;
        public float HEIGHT = 1.95f;
        public float DEPTH = 2.08f;

        public Vector3 Position;
        public Matrix World;
        public Model Model;

        private float AngleZ;
        private Floor Floor;

        public AimingArrow(PuzzleBooble3dGame game, Floor floor) : base(game) 
        {
            Floor = floor;

            AngleZ = 0;
            Position = Floor.Position + new Vector3(Floor.WIDTH/2, 0, 0);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            Model = Game.Content.Load<Model>("Arrow/AimingArrow");
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
