using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace PuzzleBooble3DClone.GameComponents
{
    public class ContentRepository : PuzzleBoobleDrawableGameComponent
    {
        public Texture2D BlueTexture;
        public Texture2D GreenTexture;
        public Texture2D RedTexture;
        public Texture2D YellowTexture;
        public Texture2D OrangeTexture;
        public Texture2D PurpleTexture;
        public Texture2D SilverTexture;
        public Texture2D DarkGreyTexture;

        public SpriteFont SpriteFont;

        public ContentRepository(PuzzleBooble3dGame puzzleGame) : base(puzzleGame) { }

        protected override void LoadContent()
        {
            base.LoadContent();
            BlueTexture = Game.Content.Load<Texture2D>("Spheres/Blue");
            GreenTexture = Game.Content.Load<Texture2D>("Spheres/Green");
            RedTexture = Game.Content.Load<Texture2D>("Spheres/Red");
            YellowTexture = Game.Content.Load<Texture2D>("Spheres/Yellow");
            OrangeTexture = Game.Content.Load<Texture2D>("Spheres/Orange");
            PurpleTexture = Game.Content.Load<Texture2D>("Spheres/Purple");
            SilverTexture = Game.Content.Load<Texture2D>("Spheres/Silver");
            DarkGreyTexture = Game.Content.Load<Texture2D>("Spheres/DarkGrey");

            SpriteFont = Game.Content.Load<SpriteFont>("Font");
        }
    }
}
