using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    private List<IObserver> _observers = new List<IObserver>(24);


    public void addObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void removeObserver(IObserver observer)
    {
        if (_observers.Count > 0)
        {
            int index = _observers.IndexOf(observer);
            _observers[index] = _observers[_observers.Count - 1];
        }

        _observers.RemoveAt(_observers.Count - 1);
    }

    public void notify(GameObject obj, ObsEvent _event)
    {
        foreach (IObserver observer in _observers)
        {
            observer.onNotify(obj, _event);
        }
    }

}
