using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace pest_control
{
    class Menu : Controller
    {
        private String titleString = "PestControl";
        private List<String> commands;
        private int currentCommand = 0;
        private bool waitForKeysUp = false;

        public Menu(EventQueue eventQueue) : base(eventQueue) {
            commands = new List<String>();
            commands.Add("New Game");
            commands.Add("Options");
            commands.Add("Quit");
        }

        public String getTitleString() { return titleString; }

        public List<String> getCommands() { return commands; }

        public int getCurrentCommand() { return currentCommand; }

        public override void Update()
        {
            if(waitForKeysUp) {
                if (Keyboard.GetState().GetPressedKeys().Count() == 0)
                {
                    waitForKeysUp = false;
                }
                return;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && currentCommand > 0)
            {
                currentCommand--;
                waitForKeysUp = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down) && currentCommand < commands.Count - 1)
            {
                currentCommand++;
                waitForKeysUp = true;
            } 
            else if (Keyboard.GetState().IsKeyDown(Keys.Enter) )
            {
                if (currentCommand == 0) { 
                    
                    eventQueue.EnqueueEvent("SYSTEM", new Event("NEW_GAME")); }
            }
        }
    }
}
