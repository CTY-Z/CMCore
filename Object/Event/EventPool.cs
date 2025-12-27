using System;
using System.Collections.Concurrent;
using UnityEngine;

namespace CMFramework.Core
{
    public class EventPool<T>
    {
        private readonly ConcurrentQueue<Event> que_event;
        private EventHandler<T> m_defualtHandler;

        public EventPool()
        {
            que_event = new ConcurrentQueue<Event>();
            m_defualtHandler = null;
        }
    }
}
