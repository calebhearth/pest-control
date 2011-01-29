using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace pest_control
{
    class Player
    {

        int playerNumber;
        Game game;

        public Player(int playerNumber, Game g)
        {
            this.playerNumber = playerNumber;
            this.game = g;
        }

        public void Update()
        {
            if (isKeyDown(Keys.Up) && isKeyDown(Keys.Left))
            {
                game.getCurrentController().inputDirection(playerNumber,Direction.UpLeft);
            }
            else if (isKeyDown(Keys.Up) && isKeyDown(Keys.Right))
            {
                game.getCurrentController().inputDirection(playerNumber, Direction.UpRight);
            }
            else if (isKeyDown(Keys.Down) && isKeyDown(Keys.Left))
            {
                game.getCurrentController().inputDirection(playerNumber, Direction.DownLeft);
            }
            else if (isKeyDown(Keys.Down) && isKeyDown(Keys.Right))
            {
                game.getCurrentController().inputDirection(playerNumber, Direction.DownRight);
            }
            else if (isKeyDown(Keys.Down))
            {
                game.getCurrentController().inputDirection(playerNumber, Direction.Down);
            }
            else if (isKeyDown(Keys.Up))
            {
                game.getCurrentController().inputDirection(playerNumber, Direction.Up);
            }
            else if (isKeyDown(Keys.Left))
            {
                game.getCurrentController().inputDirection(playerNumber, Direction.Left);
            }
            else if (isKeyDown(Keys.Right))
            {
                game.getCurrentController().inputDirection(playerNumber, Direction.Right);
            }

            if (isKeyDown(Keys.Space) || isKeyDown(Keys.Enter)) {
                game.getCurrentController().inputShoot(1);
            }

            if(Keyboard.GetState().GetPressedKeys().Count() == 0) {
                game.getCurrentController().inputNone(1);
            }
        }

        public bool isKeyDown(Keys k)
        {
            return Keyboard.GetState().IsKeyDown(k);
        }

    }
}
