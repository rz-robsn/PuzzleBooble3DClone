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

        private static Rectangle SRC_RECTANGLE = new Rectangle(336, 1599, 13, 11);
        private static Vector2 POSITION = new Vector2(50, 15);

        public int Value;

        public Score(PuzzleBooble3dGame puzzlegame) : base(puzzlegame) 
        {
            
        }

        public override void  Update(GameTime gameTime)
        {
 	         base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
