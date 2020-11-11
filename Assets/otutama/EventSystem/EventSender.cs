using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace otutama
{
    public class EventSender : MonoBehaviour
    {
        [SerializeField]
        private EventObject eventObject = default;

        public void Send()
        {
            eventObject.Send();
        }
    }
}