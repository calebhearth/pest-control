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
        private int numberOfChromosomes;
        private List<Chromosome> chromosomes = new List<Chromosome>();

        public Critter(BoundingBox boundingBox)
        {
            decider = new Decider();
            this.BoundingBox = boundingBox;
            this.speed = 1;
            this.Sprite = "critter-left";
            this.health = 10;
            this.numberOfChromosomes = 2;

            this.assignChromosomes(numberOfChromosomes);
        }

        private void assignChromosomes(int num)//generates chromosomes according to value of numberOfChromasomes, then modifies the critter's attributes accordingly
        {
            for (int i = 0; i < numberOfChromosomes; i++)
            {
                chromosomes.Add(new Chromosome((ChromosomeType)rand.Next(9) + 1, true));
            }

            foreach (Chromosome c in chromosomes)
            {
                if (c.GetType().ToString() == "SpeedMod")//only the speed modifier chromosome is implemented here, as the other attributes do not yet exist to be modified
                {
                    this.speed *= 2;
                }
            }
        }

        public void takeDamage(DamageType damageType, double baseDamage)
        {
            double damageDealt = baseDamage;

            foreach (Chromosome c in chromosomes)
            {
                if (damageType.ToString() == c.ToString())
                {
                    damageDealt *= 0.5;
                }
            }

            this.health -= damageDealt;
        }

        public override void act()
        {
            this.direction = decider.decide();
            base.act();
        }
    }
}
