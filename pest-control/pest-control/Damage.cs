using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pest_control
{
    public class Damage
    {
        public DamageType type;
        public double rating;

        public Damage(DamageType type, double rating)
        {
            this.type = type;
            this.rating = rating;
        }
    }
}
