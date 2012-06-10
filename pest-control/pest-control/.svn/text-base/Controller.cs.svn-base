using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pest_control
{
    public abstract class Controller
    {
        protected EventQueue eventQueue;

        public Controller(EventQueue eventQueue) { this.eventQueue = eventQueue; }

        public abstract void Update();

        public virtual void inputNone(int playerNumber) { }
        public virtual void inputDirection(int playerNumber, Direction d) { }
        public virtual void inputShoot(int playerNumber) { }
    }
}
