using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace otutama
{
    public class UnscaledTimer : MonoBehaviour
    {
        [SerializeField]
        private float interval = default;
        [SerializeField]
        private bool repeat = default;
        [SerializeField]
        private UnityEvent events = new UnityEvent();
        private float time;
        private void OnEnable()
        {
            time = 0;
        }

        private void Update()
        {
            UpdateTimer();
        }
            private void UpdateTimer() {
            time += Time.deltaTime;
            if( time >= interval){
                events.Invoke();
                if( !repeat ){
                    enabled = false;
                }
            }
        }
    }
}