using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialDone : Subject
{
    GameObject TBun;
    // Start is called before the first frame update
    public tutorialDone()
    {
        addObserver(AchievementManager.Instance);
        TBun = GameObject.FindGameObjectWithTag("TBun");
    }

    // Update is called once per frame
    public void Update()
    {
        if (TBun.activeInHierarchy == false)
        {
            notify(null, ObsEvent.TUTORIAL_DONE);
            notify(null, ObsEvent.GAME_BEGINS);
        }
    }
}
