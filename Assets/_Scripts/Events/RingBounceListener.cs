using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class RingEvent : UnityEvent<GameObject> { }
public class RingBounceListener : MonoBehaviour
{
    public Event @event;
    public RingEvent _eventResponse = new RingEvent();

    private void OnEnable()
    {
        @event.RegisterObserver(this); 
    }
    private void OnDisable()
    {
        @event.UnregisterObserver(this);
    }
    public void OnEventOccurred(GameObject @object)
    {
        _eventResponse.Invoke(@object); 
    }
}
