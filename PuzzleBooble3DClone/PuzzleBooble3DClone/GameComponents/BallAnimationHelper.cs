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
        private Ball Ball;

        public BallAnimationHelper(Ball ball) 
        {
            Ball = ball;
        }

        public void Update(GameTime gameTime) 
        {
        
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
