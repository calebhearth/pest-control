using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace pest_control
{
    public abstract class View
    {
        protected GraphicsDevice graphicsDevice;

        public View(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
        }

        public abstract void LoadContent(ContentManager contentManager);

        public abstract void Draw();
    }
}
