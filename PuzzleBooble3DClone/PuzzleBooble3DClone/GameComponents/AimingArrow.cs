using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PuzzleBooble3DClone.GameComponents
{
    public class AimingArrow : PuzzleBoobleDrawableGameComponent
    {
        public static readonly float WIDTH = 18.08f;
        public static readonly float HEIGHT = 1.95f;
        public static readonly float DEPTH = 2.08f;
        private static readonly float INITIAL_ANGLE_Z = (float)Math.PI/2;
        private static readonly float ROTATION_SPEED = (float)Math.PI/60;
        private static readonly float ANGLE_Z_LOWER_BOUND = -(float)Math.PI / 2 + 0.2f;
        private static readonly float ANGLE_Z_HIGHER_BOUND = (float)Math.PI / 2 - 0.2f;

        public Vector3 Position;
        public Matrix World;
        public Model Model;

        private float AngleZ;        
        private Floor Floor;

        private Vector3 CurrentBallPosition 
        {
            get
            { 
                return new Vector3((float)Math.Sin(INITIAL_ANGLE_Z + AngleZ), (float)Math.Cos(INITIAL_ANGLE_Z + AngleZ), 0);
            } 
            set {} 
        }

        public AimingArrow(PuzzleBooble3dGame game, Floor floor) : base(game) 
        {
            Floor = floor;

            AngleZ = 0;
            Position = Floor.Position + new Vector3(Floor.WIDTH/2, 0, Ball.BALL_RADIUS);
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

            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left)) 
            {
                AngleZ = MathHelper.Clamp(AngleZ + ROTATION_SPEED, ANGLE_Z_LOWER_BOUND, ANGLE_Z_HIGHER_BOUND);
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                AngleZ = MathHelper.Clamp(AngleZ - ROTATION_SPEED, ANGLE_Z_LOWER_BOUND, ANGLE_Z_HIGHER_BOUND);
            }

            World = Matrix.CreateRotationZ(AngleZ) * Matrix.CreateTranslation(Position) ;
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

        public Vector3 GetCurrentDirection() 
        {
            return new Vector3(-(float)Math.Sin(INITIAL_ANGLE_Z + AngleZ), (float)Math.Cos(INITIAL_ANGLE_Z + AngleZ), 0);
        }
    }
}
