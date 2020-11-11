using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace otutama
{
    public class EventReceiver : MonoBehaviour, IEventReceiver
    {
        [SerializeField]
        private EventObject eventObject = default;

        [SerializeField]
        private UnityEvent events = new UnityEvent();

        private void Awake()
        {
            eventObject.AddObserver(this);
        }

        private void OnDestroy()
        {
            eventObject.RemoveObserver(this);
        }

        public void OnRecieve()
        {
            events.Invoke();
        }
    }

}