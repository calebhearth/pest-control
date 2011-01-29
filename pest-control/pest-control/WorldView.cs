using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace pest_control
{
    class WorldView : View
    {
        protected SpriteBatch worldBatch;

        public WorldView(GraphicsDevice graphicsDevice, World world) : base(graphicsDevice) { }

        public override void LoadContent(ContentManager contentManager)
        {
            worldBatch = new SpriteBatch(graphicsDevice);
        }

        public override void Draw()
        {
            graphicsDevice.Clear(Color.Pink);
        }

    }
}
