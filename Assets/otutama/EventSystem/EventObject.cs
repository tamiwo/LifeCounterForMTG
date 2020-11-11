using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace otutama
{
    public interface IEventReceiver
    {
        void OnRecieve();
    }

    [CreateAssetMenu(menuName="otutama/event")]
    public class EventObject : ScriptableObject
    {
        List<IEventReceiver> observers = new List<IEventReceiver>();
        
        public void AddObserver(IEventReceiver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IEventReceiver observer)
        {
            observers.Remove(observer);
        }

        public void Send()
        {
            observers.ForEach(observers => observers.OnRecieve());
        }
    }
}