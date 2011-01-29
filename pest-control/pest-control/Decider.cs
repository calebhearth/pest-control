using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pest_control
{
    public class Decider
    {
        private static Random rand = new Random();
        public Direction decide()
        {
            return (Direction)rand.Next(8) + 1;
        }
    }
}
