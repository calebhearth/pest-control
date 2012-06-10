using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pest_control
{
    public class Attributes
    {
        public int horniness;
        public int hunger;
        public int thirst;

        private int critterSize;

        public Attributes(int critterSize)
        {
            this.critterSize = critterSize;

            horniness = 0;
            hunger = 0;
            thirst = 0;
        }

        public void Update()
        {
            horniness += (6 - critterSize);
            hunger += critterSize;
            thirst += (int)(critterSize * 1.5);
        }
    }
}
