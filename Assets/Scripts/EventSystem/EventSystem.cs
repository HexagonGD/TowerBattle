using System;
using System.Collections.Generic;

namespace TowerBattle
{
    public static class EventSystem
    {
        private static IDictionary<Type, object> _containers = new Dictionary<Type, object>();

        public static void AddListener<T>(object listener, Action<T> listenerAction)
        {
            if(_containers.TryGetValue(typeof(T), out var container))
            {
                var eventContainer = container as EventContainer<T>;
                eventContainer.AddEvent(listener, listenerAction);
            }
            else
            {
                var eventContainer = new EventContainer<T>(listener, listenerAction);
                _containers.Add(typeof(T), eventContainer);
            }    
        }

        public static void RemoveListener<T>(object listener)
        {
            if(_containers.TryGetValue(typeof(T), out var container))
            {
                var eventContainer = container as EventContainer<T>;
                eventContainer.RemoveEvent(listener);
            }
        }

        public static void Execute<T>(T eventArg)
        {
            if (_containers.TryGetValue(typeof(T), out var container))
            {
                var eventContainer = container as EventContainer<T>;
                eventContainer.Execute(eventArg);
            }
        }
    }
}