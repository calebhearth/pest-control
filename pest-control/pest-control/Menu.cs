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
        { }

        public override void inputDirection(int playerNumber, Direction d)
        {
            if (playerNumber != 1 || waitForKeysUp) return;

            if ((d == Direction.Up || d == Direction.UpLeft || d == Direction.UpRight) && currentCommand > 0)
            {
                currentCommand--;
            }
            else if ((d == Direction.Down || d == Direction.DownLeft || d == Direction.DownRight) && currentCommand < commands.Count-1)
            {
                currentCommand++;
            }

            waitForKeysUp = true;
        }

        public override void inputShoot(int playerNumber)
        {
            if (playerNumber != 1 || waitForKeysUp) return;

            if (currentCommand == 0)
            {
                eventQueue.EnqueueEvent("SYSTEM", new Event("NEW_GAME"));
            }

            waitForKeysUp = true;
        }

        public override void inputNone(int playerNumber)
        {
            if (playerNumber != 1) return;

            waitForKeysUp = false;
        }
    }
}
