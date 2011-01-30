using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pest_control
{
    public class Chromosome
    {
        public ChromosomeType Type
        {
            get { return type; }
        }

        public bool Increase
        {
            get { return increase; }
        }

        ChromosomeType type;
        bool increase;

        public Chromosome(ChromosomeType type, bool value)
        {
            this.type = type;
            this.increase = value;
        }

    }
}
