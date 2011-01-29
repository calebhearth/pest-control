using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
