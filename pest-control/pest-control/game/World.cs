using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace pest_control
{
    class World
    {
        private static Random rand = new Random();

        private readonly int HEIGHT;
        private readonly int WIDTH;
        private readonly int CELL_SIZE;
        private readonly int NUM_PLAYERS;
        private static int NUM_CRITTERS = 50;

        public List<Thing> Things
        {
            get { return things; }
            set { things = value; }
        }

        private List<Thing> things;

        public World(int cellsize, int height, int width, int players)
        {
            this.HEIGHT = height;
            this.WIDTH = width;
            this.CELL_SIZE = cellsize;
            this.NUM_PLAYERS = players;

            //PopulateTerrain();
            PopulateCritters();
            PopulatePlayers();
        }

        private void PopulateTerrain()
        {
            throw new NotImplementedException();
        }
        private void PopulateCritters()
        {
            for (int i = 0; i < NUM_CRITTERS; i++)
            {
                this.things.Add(new Critter(boundingBox: new BoundingBox(rand.Next(WIDTH), 
                                                               rand.Next(HEIGHT), 
                                                               CELL_SIZE * 3, 
                                                               CELL_SIZE * 3)
                                           )
                               );
            }
        }
        private void PopulatePlayers()
        {
            for (int i = 0; i < NUM_PLAYERS; i++)
            {
                this.things.Add(
                    new Character(characterIndex: i, 
                                  boundingBox: new BoundingBox(rand.Next(WIDTH), 
                                                               rand.Next(HEIGHT), 
                                                               CELL_SIZE * 3, 
                                                               CELL_SIZE * 3)
                                  )
                               );
            }
        }
    }
}
