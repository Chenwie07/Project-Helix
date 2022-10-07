using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventResponse : UnityEvent { }
//public class UnityGameEventListener : UnityEvent<param>{ } to use parameters. 
public class EventListener : MonoBehaviour
{
    public Event @event;
    public EventResponse gameEventResponse;

    private void OnEnable()
    {
        @event.RegisterObserver(this);
    }
    private void OnDisable()
    {
        @event.UnregisterObserver(this);
    }
    //public void OnEventOccurred()
    //{
    //    gameEventResponse.Invoke(); // invoke the registered method in the inspector. 
    //}
    public void OnEventOccurred() => gameEventResponse.Invoke(); 
}
