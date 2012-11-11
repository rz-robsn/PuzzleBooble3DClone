using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PuzzleBooble3DClone.GameComponents
{
    public abstract class PuzzleBoobleDrawableGameComponent : DrawableGameComponent
    {
        public PuzzleBooble3dGame PuzzleBooble3dGame 
        {
            get 
            {
                return (PuzzleBooble3dGame)this.Game; 
            }
        }

        public PuzzleBoobleDrawableGameComponent(PuzzleBooble3dGame puzzleGame) : base(puzzleGame) { }
    }
}
