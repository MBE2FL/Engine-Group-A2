using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObsEvent
{
    TEST_EVENT,
    ENEMY_DIED
}

public interface IObserver
{
    void onNotify(GameObject obj, ObsEvent _event);
}
