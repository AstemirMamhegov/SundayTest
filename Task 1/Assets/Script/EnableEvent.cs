using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnableEvent : MonoBehaviour
{
    public UnityEvent onEnableEvent;
    public float Delay;

    private void OnEnable()
    {
        if (Delay > 0)
            Invoke(nameof(DelayEnable), Delay);
        else
            DelayEnable();
    }

    private void DelayEnable()
    {
        onEnableEvent.Invoke();
    }
}
