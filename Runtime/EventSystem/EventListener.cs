using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameDevUtils.EventSystem
{
    public class EventListener : MonoBehaviour
    {
        [SerializeField] UnityEvent listener;
        [SerializeField] VoidEventChannel eventChannel;

        private void OnEnable()
        {
            eventChannel.events += OnEventRaised;
        }

        private void OnDisable()
        {
            eventChannel.events -= OnEventRaised;
        }

        private void OnEventRaised()
        {
            listener?.Invoke();
        }
    }
}