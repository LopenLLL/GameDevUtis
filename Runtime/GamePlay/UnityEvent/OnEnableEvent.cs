using System;
using UnityEngine;

public class OnEnableEvent : MonoBehaviour
{
    [SerializeField] private UnityEngine.Events.UnityEvent onEnable;
    [SerializeField] private UnityEngine.Events.UnityEvent onDisable;

    private void OnEnable()
    {
        onEnable.Invoke();
    }

    private void OnDisable()
    {
        onDisable.Invoke();
    }
}