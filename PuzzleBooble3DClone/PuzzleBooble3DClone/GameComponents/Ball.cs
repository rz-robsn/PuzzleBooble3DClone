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
        public float Acceleration;
        public Vector3 Direction;
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

            Speed += Acceleration;
            Position += Speed * Direction;

            World = Matrix.Identity;            
            AnimationHelper.Update(gameTime);
            World *= Matrix.CreateTranslation(Position);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            AnimationHelper.Draw(gameTime);
        }

        public bool IsMoving() 
        {
            return Speed > 0;
        }

        //public bool IntersectsWithBall(Ball ball) 
        //{
        
        //}

        public void Destroy()
        {
            AnimationHelper.Destroy();
        }

        public void FallDown()
        {
            AnimationHelper.FallDown();
        }

        public void Load()
        {
            AnimationHelper.Load();
        }

        public void GoDark()
        {
            AnimationHelper.GoDark();
        }
        public bool IntersectsWithBall(Ball b) 
        {
            foreach (ModelMesh mesh in Model.Meshes)
            {
                BoundingSphere boundingSphere = mesh.BoundingSphere.Transform(World);
                foreach(ModelMesh bMesh in b.Model.Meshes)
                {
                    BoundingSphere ballboundingSphere = bMesh.BoundingSphere.Transform(b.World);
                    if (ballboundingSphere.Intersects(boundingSphere)) 
                    {
                        return true;
                    }
                }
            }
            return false;   
        }

        public bool InterSectsWithBox(BoundingBox box) 
        {
            foreach (ModelMesh mesh in Model.Meshes) 
            {
                BoundingSphere boundingSphere = mesh.BoundingSphere.Transform(World);
                if (boundingSphere.Intersects(box)) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
