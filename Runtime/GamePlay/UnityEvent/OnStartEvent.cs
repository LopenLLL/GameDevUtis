using UnityEngine;
using UnityEngine.Events;

public class OnStartEvent : MonoBehaviour
{
    public UnityEvent onStart;

    private void Start()
    {
        onStart.Invoke();
    }
}