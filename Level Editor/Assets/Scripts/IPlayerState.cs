using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerStates
{
    Walk,
    Jump
}

public interface IPlayerState
{
    void entry(Movement movement);
    IPlayerState input();
    void update();

    void fixedUpdate();
}
