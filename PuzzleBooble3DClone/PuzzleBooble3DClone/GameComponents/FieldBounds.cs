using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PuzzleBooble3DClone.GameComponents
{
    public class FieldBounds : PuzzleBoobleGameComponent
    {
        public BoundingBox Top { get; private set; }
        public BoundingBox Left { get; private set; }
        public BoundingBox Right { get; private set; }

        private Floor Floor;

        public FieldBounds(PuzzleBooble3dGame puzzleGame, Floor floor) : base(puzzleGame)
        {
            Floor = floor;

            Left = new BoundingBox(min: Floor.Position + new Vector3(Floor.WIDTH/2, -Floor.HEIGHT/2, 0),
                                  max: Floor.Position + new Vector3(-Floor.WIDTH/2, -Floor.HEIGHT/2, 2*Ball.BALL_RADIUS));  
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
