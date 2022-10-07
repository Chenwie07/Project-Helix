using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ring Event")]
public class Event : ScriptableObject
{
    private List<EventListener> Observers = new List<EventListener>();
    private List<RingBounceListener> _ringBounceListeners = new List<RingBounceListener>(); 

    internal void RegisterObserver(EventListener observer)
    {
        Observers.Add(observer);  
    }
    internal void RegisterObserver(RingBounceListener observer)
    {
        _ringBounceListeners.Add(observer);
    }

    internal void UnregisterObserver(RingBounceListener ringBounceListener)
    {
        _ringBounceListeners.Remove(ringBounceListener);
    }
    internal void UnregisterObserver(EventListener observer)
    {
        Observers.Remove(observer);
    }
    public void Occurred()
    {
        foreach (EventListener observer in Observers)
        {
            observer.OnEventOccurred(); 
        }
    }
    public void Occurred(GameObject @object)
    {
        foreach (RingBounceListener observer in _ringBounceListeners)
        {
            observer.OnEventOccurred(@object); 
        }
    }
}
