using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace pest_control
{
    public class BoundingBox
    {

        public Location TopLeft
        {
            get { return topLeft; }
            set { topLeft = value; }
        }

        public Location BottomRight
        {
            get { return bottomRight; }
            set { bottomRight = value; }
        }

        private Location topLeft;
        private Location bottomRight;

        public BoundingBox(Location topLeft, Location bottomRight)
        {
            this.TopLeft = topLeft;
            this.bottomRight = bottomRight;
        }

        public BoundingBox(Location topLeft, int height, int width)
        {
            this.TopLeft = topLeft;
            this.BottomRight = new Location(topLeft.Y + height, topLeft.X + width);
        }

        public BoundingBox(int x, int y, int height, int width)
        {
            this.TopLeft = new Location(x, y);
            this.BottomRight = new Location(this.TopLeft.Y + height, this.TopLeft.X + width);
        }

        public bool IntersectsWith(BoundingBox that)
        {
            Rectangle thisRect = new Rectangle(this.TopLeft.X, this.TopLeft.Y, (this.BottomRight.X - this.TopLeft.X), (this.BottomRight.Y - this.TopLeft.Y));
            Rectangle thatRect = new Rectangle(that.TopLeft.X, that.TopLeft.Y, (that.BottomRight.X - that.TopLeft.X), (that.BottomRight.Y - that.TopLeft.Y));
            
            return thisRect.Intersects(thatRect);
        }

        public int DistanceTo(BoundingBox that)
        {
            Rectangle thisRect = new Rectangle(this.TopLeft.X, this.TopLeft.Y, (this.BottomRight.X - this.TopLeft.X), (this.BottomRight.Y - this.TopLeft.Y));
            Rectangle thatRect = new Rectangle(that.TopLeft.X, that.TopLeft.Y, (that.BottomRight.X - that.TopLeft.X), (that.BottomRight.Y - that.TopLeft.Y));

            return (int)Math.Sqrt((thisRect.Center.X - thatRect.Center.X) * (thisRect.Center.X - thatRect.Center.X) + (thisRect.Center.Y - thatRect.Center.Y) * (thisRect.Center.Y - thatRect.Center.Y));
        }
    }
}
