using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace pest_control
{
    public abstract class MovingThing : Thing
    {
        protected Direction direction;
        protected int speed;

        public virtual void act()
        {
            switch (this.direction)
            {
                case Direction.Up:
                    this.boundingBox.TopLeft.Y -= speed;
                    break;
                case Direction.UpRight:
                    this.boundingBox.TopLeft.Y -= speed;
                    this.boundingBox.TopLeft.X += speed;
                    break;
                case Direction.Right:
                    this.boundingBox.TopLeft.X += speed;
                    break;
                case Direction.DownRight:
                    this.boundingBox.TopLeft.Y += speed;
                    this.boundingBox.TopLeft.X += speed;
                    break;
                case Direction.Down:
                    this.boundingBox.TopLeft.Y += speed;
                    break;
                case Direction.DownLeft:
                    this.boundingBox.TopLeft.Y += speed;
                    this.boundingBox.TopLeft.X -= speed;
                    break;
                case Direction.Left:
                    this.boundingBox.TopLeft.X -= speed;
                    break;
                case Direction.UpLeft:
                    this.boundingBox.TopLeft.X -= speed;
                    this.boundingBox.TopLeft.Y -= speed;
                    break;
                default:
                    this.boundingBox.TopLeft.X = 0;
                    this.boundingBox.TopLeft.Y = 0;
                    break;
            }
        }
    }
}
