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
                    this.BoundingBox.TopLeft.Y -= speed;
                    this.BoundingBox.TopLeft.Y -= speed;
                    break;
                case Direction.UpRight:
                    this.BoundingBox.TopLeft.Y -= speed;
                    this.BoundingBox.TopLeft.X += speed;
                    break;
                case Direction.Right:
                    this.BoundingBox.TopLeft.X += speed;
                    break;
                case Direction.DownRight:
                    this.BoundingBox.TopLeft.Y += speed;
                    this.BoundingBox.TopLeft.X += speed;
                    break;
                case Direction.Down:
                    this.BoundingBox.TopLeft.Y += speed;
                    break;
                case Direction.DownLeft:
                    this.BoundingBox.TopLeft.Y += speed;
                    this.BoundingBox.TopLeft.X -= speed;
                    break;
                case Direction.Left:
                    this.BoundingBox.TopLeft.X -= speed;
                    break;
                case Direction.UpLeft:
                    this.BoundingBox.TopLeft.X -= speed;
                    this.BoundingBox.TopLeft.Y -= speed;
                    break;
                default:
                    this.BoundingBox.TopLeft.X = 0;
                    this.BoundingBox.TopLeft.Y = 0;
                    break;
            }
        }
    }
}
