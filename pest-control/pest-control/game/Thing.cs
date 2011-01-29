using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace pest_control
{
    public abstract class Thing
    {
        public BoundingBox BoundingBox
        {
            get { return boundingBox; }
            set { boundingBox = value; }
        }

        protected bool IsSolid
        {
            get { return isSolid; }
            set { isSolid = value; }
        }

        protected string Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        protected BoundingBox boundingBox;
        private bool isSolid;
        private string sprite;

    }
}
