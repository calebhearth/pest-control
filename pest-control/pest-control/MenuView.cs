using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace pest_control
{
    class MenuView : View
    {
        private Menu menu;
        SpriteBatch menuBatch;
        SpriteFont menuFont;

        public MenuView(GraphicsDevice graphicsDevice, Menu menu) : base(graphicsDevice)
        {
            this.menu = menu;
        }

        public override void LoadContent(ContentManager contentManager)
        {
            menuBatch = new SpriteBatch(graphicsDevice);
            menuFont = contentManager.Load<SpriteFont>("menuFont");
        }

        public override void Draw()
        {
            menuBatch.Begin();
            graphicsDevice.Clear(Color.Black);
            menuBatch.DrawString(menuFont, menu.getTitleString(), new Vector2(10,20), Color.Green, 0, new Vector2(0,0), 1.0f, SpriteEffects.None, 0.5f);
            Vector2 stringMeasure = menuFont.MeasureString("X");
            for (int i = 0; i < menu.getCommands().Count; i++)
            {
                menuBatch.DrawString(menuFont, menu.getCommands().ElementAt(i), new Vector2(10, 20+(stringMeasure.Y * (i+2))), menu.getCurrentCommand()==i?Color.Yellow:Color.Green, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
            }
            menuBatch.End();

            
        }

    }
}
