using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Observer
{
    public class Subject
    {
        private List<AObserver> _observers = new List<AObserver>();

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                Debug.Log(observer.GetType().Name);
                observer.OnNotify();
            }
        }

        public void AddObserver(AObserver aObserver)
        {
            _observers.Add(aObserver);
        }

        public void RemoveObserver(AObserver aObserver)
        {
            if (_observers.Contains(aObserver))
                _observers.Remove(aObserver);
        }
    }
}