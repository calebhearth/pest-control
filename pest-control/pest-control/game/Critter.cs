using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace pest_control
{
    public class Critter : LivingThing
    {
        private Decider decider;
        private static Random rand = new Random();
        //private List<Chromosome>;

        public Critter(BoundingBox boundingBox)
        {
            decider = new Decider();
            this.BoundingBox = boundingBox;
            this.speed = 1;
        }

        public override void act()
        {
            this.direction = decider.decide();
            base.act();
        }
    }
}
