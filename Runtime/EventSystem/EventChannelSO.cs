using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameDevUtils.EventSystem
{
    public abstract class EventChannelSO : ScriptableObject
    {
        public UnityAction events;

        public void Invoke() => events?.Invoke();
    }
    
    public abstract class EventChannelSO<T> : ScriptableObject
    {
        public UnityAction<T> events;
        public void Invoke(T t) => events?.Invoke(t);
    }
}