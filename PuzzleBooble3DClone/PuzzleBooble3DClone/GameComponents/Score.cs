using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PuzzleBooble3DClone.GameComponents
{
    public class Score : PuzzleBoobleDrawableGameComponent
    {
        public static int POINTS_PER_BALLS_POPPED = 10;
        public static int POINTS_PER_BALLS_HANGED = 20;

        DepthStencilState DepthStateEnabled;

        private static Vector2 POSITION = new Vector2(50, 15);
        private static Vector2 MESSAGE_POSITION = new Vector2(275, 15);

        public int Value;
        public String Message;

        public Score(PuzzleBooble3dGame puzzlegame) : base(puzzlegame) 
        {
            DepthStateEnabled = new DepthStencilState();
            DepthStateEnabled.DepthBufferEnable = true; /* Enable the depth buffer */
            //depthState.DepthBufferWriteEnable = true; /* When drawing to the screen, write to the depth buffer */

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void  Update(GameTime gameTime)
        {
 	         base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            SpriteBatch spriteBatch = new SpriteBatch(PuzzleBooble3dGame.GraphicsDevice);
            spriteBatch.Begin();
            spriteBatch.DrawString(PuzzleBooble3dGame.ContentRepository.SpriteFont, "Score:", POSITION , Color.GreenYellow);
            spriteBatch.DrawString(PuzzleBooble3dGame.ContentRepository.SpriteFont, String.Format("{0:D8}", Value), POSITION + new Vector2(2, 16), Color.WhiteSmoke);
            if (Message != null && Message.Length > 0) 
            {
                spriteBatch.DrawString(PuzzleBooble3dGame.ContentRepository.SpriteFont, Message, MESSAGE_POSITION, Color.GhostWhite);            
            }

            spriteBatch.End();

            GraphicsDevice.DepthStencilState = DepthStateEnabled;
        }

    }
}
