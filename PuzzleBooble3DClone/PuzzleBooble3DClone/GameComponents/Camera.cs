using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PuzzleBooble3DClone.GameComponents
{
    public class Camera : PuzzleBoobleGameComponent
    {
        public Matrix View {get; private set;}
        public Matrix Projection { get; private set; }

        public Camera(PuzzleBooble3dGame game) : base(game) {}

        public override void Initialize()
        {
            base.Initialize();
            View = Matrix.CreateLookAt(new Vector3(50, 0, 50), new Vector3(0, 0, 0), Vector3.UnitZ);
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 600f, 0.1f, 100f);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
