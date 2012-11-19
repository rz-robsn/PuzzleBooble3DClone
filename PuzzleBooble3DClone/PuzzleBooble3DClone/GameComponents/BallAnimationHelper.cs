using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PuzzleBooble3DClone.GameComponents
{
    public class BallAnimationHelper
    {
        private static float LOADING_BALL_SCALE_DECREASE_SPEED = 0.05f;
        private static float DESTROYED_BALL_SCALE_DECREASE_SPEED = 0.05f;
        private static float FALLING_BALL_ACCELERATION = 0.005f;
        private static float ROLLING_BALL_MINIMUM_SPEED = 0.3f;

        private static Vector3 LOADING_BALL_POSITION = new Vector3(Floor.WIDTH, Floor.HEIGHT/2, Ball.BALL_RADIUS);

        private Ball Ball;

        public enum BallState { Normal, Loading, Rolling, Destroyed, Falling, Dark };
        private BallState State;

        private float DestroyedCurrentScale;

        private float LoadingCurrentScale;

        private float CurrentRotationSpeed;
        private float CurrentAngle;

        public BallAnimationHelper(Ball ball) 
        {
            Ball = ball;
            State = BallState.Normal;

        }

        public void Update(GameTime gameTime) 
        {
            switch (State)
            {
                case BallState.Normal:
                    break;

                case BallState.Loading:
                    LoadingCurrentScale = MathHelper.Clamp(LoadingCurrentScale + LOADING_BALL_SCALE_DECREASE_SPEED, 0, 1);
                    Ball.World *= Matrix.CreateScale(LoadingCurrentScale);
                    break;
                    
                case BallState.Rolling:
                    Ball.Speed = MathHelper.Clamp(Ball.Speed + Ball.Acceleration, ROLLING_BALL_MINIMUM_SPEED, Ball.Speed + Ball.Acceleration);
                    Ball.Position += Ball.Speed * Ball.Direction;

                    CurrentRotationSpeed = Ball.Speed /10;
                    CurrentAngle += CurrentRotationSpeed;                   
                    Ball.World *= Matrix.CreateRotationX(CurrentAngle * Ball.Direction.Y) * Matrix.CreateRotationY(CurrentAngle * Ball.Direction.X);

                    break;
                case BallState.Destroyed:
                    DestroyedCurrentScale = MathHelper.Clamp(DestroyedCurrentScale - DESTROYED_BALL_SCALE_DECREASE_SPEED, 0 , 1);
                    Ball.World = Matrix.CreateScale(DestroyedCurrentScale);
                    break;
                case BallState.Falling:
                    Ball.Speed += Ball.Acceleration;
                    Ball.Position += Ball.Speed * Ball.Direction;
                    CurrentRotationSpeed = Ball.Speed /10;
                    CurrentAngle += CurrentRotationSpeed;                   
                    Ball.World *= Matrix.CreateRotationX(CurrentAngle * Ball.Direction.Y) * Matrix.CreateRotationY(CurrentAngle * Ball.Direction.X);


                    break;
                case BallState.Dark:
                    break;
                default:
                    break;
            }
        }

        public void Normalize() 
        {
            Ball.Speed = 0;
            Ball.Acceleration = 0;
            State = BallState.Normal;
        }

        public void Roll() 
        {
            State = BallState.Rolling;
        }

        public void Destroy()
        {
            State = BallState.Destroyed;
            DestroyedCurrentScale = 1;
        }

        public void FallDown()
        {
            State = BallState.Falling;
            Ball.Direction = Vector3.UnitX;
            Ball.Acceleration = FALLING_BALL_ACCELERATION;
            Ball.Speed = 0;
            CurrentAngle = 0;
        }

        public void Load()
        {
            State = BallState.Loading;
            LoadingCurrentScale = 0;
        }

        public void GoDark()
        {
            State = BallState.Dark;
        }

        public void Draw(GameTime gameTime) 
        {
            foreach (ModelMesh mesh in Ball.Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.TextureEnabled = true;
                    effect.Texture = GetTexture();
                    effect.EnableDefaultLighting();
                    effect.World = Ball.World;
                    effect.View = Ball.PuzzleBooble3dGame.Camera.View;
                    effect.Projection = Ball.PuzzleBooble3dGame.Camera.Projection;
                }

                mesh.Draw();
            }
        }

        public Texture2D GetTexture() 
        {
            ContentRepository contentRepository = Ball.PuzzleBooble3dGame.ContentRepository;

            switch (Ball.Color)
            {
                case Ball.BallColor.Blue:
                    return contentRepository.BlueTexture;
                case Ball.BallColor.Green:
                    return contentRepository.GreenTexture;
                case Ball.BallColor.Red:
                    return contentRepository.RedTexture;
                case Ball.BallColor.Yellow:
                    return contentRepository.YellowTexture;
                case Ball.BallColor.Orange:
                    return contentRepository.OrangeTexture;
                case Ball.BallColor.Purple:
                    return contentRepository.PurpleTexture;
                case Ball.BallColor.Silver:
                    return contentRepository.SilverTexture;
                case Ball.BallColor.DarkGrey:
                    return contentRepository.DarkGreyTexture;
                default:
                    return contentRepository.BlueTexture;
            }
        }
    }
}
