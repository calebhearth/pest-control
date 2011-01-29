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
        protected Dictionary<string, Texture2D> assets;
        protected World world;

        public WorldView(GraphicsDevice graphicsDevice, World world) : base(graphicsDevice) {
            assets = new Dictionary<string, Texture2D>();
            this.world = world;
        }

        public override void LoadContent(ContentManager contentManager)
        {
            worldBatch = new SpriteBatch(graphicsDevice);
            assets["player-front-step-left"] = contentManager.Load<Texture2D>("sprites\\player-front-step-left");
            assets["critter-dead"] = contentManager.Load<Texture2D>("sprites\\critter-dead");
            assets["critter-left"] = contentManager.Load<Texture2D>("sprites\\critter-left");
            assets["critter-left-smalleyes"] = contentManager.Load<Texture2D>("sprites\\critter-left-smalleyes");
            assets["critter-left-largeeyes"] = contentManager.Load<Texture2D>("sprites\\critter-left-largeeyes");
            assets["critter-sleeping"] = contentManager.Load<Texture2D>("sprites\\critter-sleeping");
            assets["critter-right-largeeyes"] = contentManager.Load<Texture2D>("sprites\\critter-right-largeeyes");
            assets["critter-right-smalleyes"] = contentManager.Load<Texture2D>("sprites\\critter-right-smalleyes");
            assets["terrain-grass"] = contentManager.Load<Texture2D>("sprites\\terrain-grass");
            assets["terrain-shrub"] = contentManager.Load<Texture2D>("sprites\\terrain-shrub");
            assets["terrain-tree"] = contentManager.Load<Texture2D>("sprites\\terrain-tree");
            assets["terrain-water"] = contentManager.Load<Texture2D>("sprites\\terrain-water");
        }

        public override void Draw()
        {
            Character c = null;
            foreach (Thing t in world.Things) { if (t is Character) { c = (t as Character); break; } }
            worldBatch.Begin();
            graphicsDevice.Clear(Color.Pink);
            int displayWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int displayHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            foreach (Thing t in world.Things)
            {
                string assetName = t.Sprite;
                int cellSizeMultiplier;
                if (t is Character)
                {
                    cellSizeMultiplier = 3;
                }
                else if (t is Critter)
                {
                    cellSizeMultiplier = 1;
                }
                else// if (t is Terrain)
                {
                    cellSizeMultiplier = 3;
                }
                worldBatch.Draw(assets[assetName], new Rectangle(t.BoundingBox.TopLeft.X - c.BoundingBox.TopLeft.X + (displayWidth / 2), t.BoundingBox.TopLeft.Y - c.BoundingBox.TopLeft.Y + (displayHeight / 2), 30 * cellSizeMultiplier, 30 * cellSizeMultiplier), Color.White);
            }
            worldBatch.End();
        }
    }
}
