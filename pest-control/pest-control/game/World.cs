﻿using System;
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
        public override void Update()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                foreach (Thing t in things)
                {
                    if(t is Character) { (t as Character).setSpeed(1); (t as Character).setDirection(Direction.Up); }
                }
            } else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                foreach (Thing t in things)
                {
                    if(t is Character) { (t as Character).setSpeed(1); (t as Character).setDirection(Direction.Down); }
                }
            } else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                foreach (Thing t in things)
                {
                    if(t is Character) { (t as Character).setSpeed(1); (t as Character).setDirection(Direction.Left);}
                }
            } else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                foreach (Thing t in things)
                {
                    if(t is Character) { (t as Character).setSpeed(1); (t as Character).setDirection(Direction.Right);}
                }
            } else {
                foreach (Thing t in things)
                {
                    if (t is Character) { (t as Character).setSpeed(0); }
                }
            }

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
