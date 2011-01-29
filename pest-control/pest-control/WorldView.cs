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
        protected Texture2D lameThingTexture;
        protected World world;

        public WorldView(GraphicsDevice graphicsDevice, World world) : base(graphicsDevice) {
            lameThingTexture = new Texture2D(graphicsDevice, 1, 1);
            lameThingTexture.SetData(new[] { Color.Black });
            this.world = world;
        }

        public override void LoadContent(ContentManager contentManager)
        {
            worldBatch = new SpriteBatch(graphicsDevice);
        }

        public override void Draw()
        {
            worldBatch.Begin();
            graphicsDevice.Clear(Color.Pink);
            foreach (Thing t in world.Things)
            {
                DrawThing(t.BoundingBox.TopLeft.X, t.BoundingBox.TopLeft.Y);
            }
            worldBatch.End();
        }

        public void DrawThing(int x, int y)
        {
            worldBatch.Draw(lameThingTexture, new Rectangle(x, y, 30, 30), Color.Black);
        }

    }
}
