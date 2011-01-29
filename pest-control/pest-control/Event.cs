using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pest_control
{
    class Event
    {

        protected String name;

        public Event(String name) { this.name = name; }

        public String getName() { return name; }

    }
}
