using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pest_control
{
    public class EventQueue
    {

        Dictionary<String, Queue<Event>> namedEventQueues;

        public EventQueue()
        {
            namedEventQueues = new Dictionary<String, Queue<Event>>();
            namedEventQueues.Add("SYSTEM", new Queue<Event>());
        }

        public void EnqueueEvent(String queueName, Event e) {
            if (namedEventQueues.ContainsKey(queueName))
            {
                namedEventQueues[queueName].Enqueue(e);
            }
        }

        public bool IsQueueEmpty(String queueName)
        {
            if (namedEventQueues.ContainsKey(queueName))
            {
                return namedEventQueues[queueName].Count == 0;
            }
            else
            {
                return true;
            }
        }

        public Event DequeueEvent(String queueName)
        {
            if (namedEventQueues.ContainsKey(queueName))
            {
                return namedEventQueues[queueName].Dequeue();
            }

            throw new Exception("u r dum.");
        }

    }
}
