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
        private static float DESTROYED_BALL_SCALE_DECREASE_SPEED = 0.05f;

        private Ball Ball;

        public enum BallState { Normal, Loading, Rolling, Destroyed, Falling, Dark };
        private BallState State;

        private float DestroyedCurrentScale;

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
                    break;
                case BallState.Rolling:
                    break;
                case BallState.Destroyed:
                    DestroyedCurrentScale = MathHelper.Clamp(DestroyedCurrentScale - DESTROYED_BALL_SCALE_DECREASE_SPEED, 0 , 1);
                    Ball.World = Matrix.CreateScale(DestroyedCurrentScale);
                    break;
                case BallState.Falling:
                    break;
                case BallState.Dark:
                    break;
                default:
                    break;
            }
        }

        public void Destroy()
        {
            State = BallState.Destroyed;
            DestroyedCurrentScale = 1;
        }

        public void FallDown()
        {
            State = BallState.Falling;
        }

        public void Load()
        {
            State = BallState.Loading;
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
