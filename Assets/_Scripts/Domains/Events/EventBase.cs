using System;
using UnityEngine;

namespace Domains.Events
{

    /// <summary>
    /// EventBase can be used to subscribe, unsubscribe and Invoke events
    /// that does not have paramenters
    /// </summary>
    public class EventBase
    {
        private event Action _action = delegate { };
        public void Invoke() => _action.Invoke();
        public void AddListener(Action listener) => _action += listener;
        public void RemoveListener(Action lisntener) => _action -= lisntener;

    }
    
    /// <summary>
    /// EventBase<T> will work exacly the same as the main class, but
    /// it CAN have paramenters (of any kind)
    /// </summary>
    public class EventBase<T>
    {
        private event Action<T> _action = delegate { };
        public void Invoke(T param) => _action.Invoke(param);
        public void AddListener(Action<T> listener) => _action += listener;
        public void RemoveListener(Action<T> lisntener) => _action -= lisntener;
    }
}