using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObsEvent
{
    PLAYER_MOVED,
    TARGETS_DOWN,
    Player_JUMPED,
    TUTORIAL_DONE,
    GAME_BEGINS,
    ADRENALINE_RUSH
}

public interface IObserver
{
    void onNotify(GameObject obj, ObsEvent _event);
}
