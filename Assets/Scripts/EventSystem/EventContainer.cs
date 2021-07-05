using System;
using System.Collections.Generic;
using System.Linq;

namespace TowerBattle
{
    public class EventContainer<T>
    {
        private event Action<T> _executeAction;
        private IDictionary<WeakReference, Action<T>> _listeners = 
            new Dictionary<WeakReference, Action<T>>();

        public EventContainer(object listener, Action<T> listenerAction)
        {
            AddEvent(listener, listenerAction);
        }

        public void AddEvent(object listener, Action<T> listenerAction)
        {
            if(!IsContain(listener))
            {
                _executeAction += listenerAction;
                _listeners.Add(new WeakReference(listener), listenerAction);
            }
        }

        public void RemoveEvent(object listener)
        {
            if(TryGetListenerReference(listener, out var listenerReference))
            {
                _executeAction -= _listeners[listenerReference];
                _listeners.Remove(listenerReference);
            }
        }

        public void Execute(T eventArg)
        {
            _executeAction?.Invoke(eventArg);
        }

        public bool IsContain(object listener)
        {
            return _listeners.Keys.Any(x => x.Target == listener);
        }

        public bool TryGetListenerReference(object listener, out WeakReference listenerReference)
        {
            listenerReference = _listeners.Keys.First(x => x.Target == listener);
            return listenerReference != null;
        }
    }
}