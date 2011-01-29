using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pest_control
{
    class World : Controller
    {

        public override void inputDirection(int playerNumber, Direction d)
        {
            if (playerNumber != 1) return;

            Character c = null;
            foreach (Thing t in things) { if (t is Character) { c = (t as Character);  } }
            c.setDirection(d);
            c.setSpeed(3);
        }

        public override void inputShoot(int playerNumber)
        {
            if (playerNumber != 1) return;
        }

        public override void inputNone(int playerNumber)
        {
            if (playerNumber != 1) return;

            Character c = null;
            foreach (Thing t in things) { if (t is Character) { c = (t as Character); break; } }

            c.setSpeed(0);
        }

        public override void Update()
        {

            foreach (Thing t in things)
            {
                if (t is MovingThing)
                {
                    (t as MovingThing).act();
                }
            }
        }
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

        public World(int cellsize, int height, int width, int players, EventQueue eventQueue)
            :base(eventQueue)
        {
            this.HEIGHT = height;
            this.WIDTH = width;
            this.CELL_SIZE = cellsize;
            this.NUM_PLAYERS = players;

            things = new List<Thing>();

            PopulateTerrain();
            PopulateCritters();
            PopulatePlayers();
        }

        private void PopulateTerrain()
        {
            int cellsWide = WIDTH / CELL_SIZE / 3;
            int cellsHigh = HEIGHT / CELL_SIZE / 3;
            TerrainType[,] terrain = new TerrainType[cellsHigh, cellsWide];

            for (int x = 0; x < cellsHigh; x++)
            {
                for (int y = 0; y < cellsWide; y++)
                {
                    if (x == 0 || x == cellsHigh - 1 || y == 0 || y == cellsWide - 1)
                    {
                        terrain[x, y] = TerrainType.Tree;
                    }
                    else
                    {
                        terrain[x, y] = (TerrainType)rand.Next(4) + 1;
                    }
                    this.things.Add(new Terrain(terrain[x, y], x * CELL_SIZE * 3, y * CELL_SIZE * 3));
                }
            }
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
