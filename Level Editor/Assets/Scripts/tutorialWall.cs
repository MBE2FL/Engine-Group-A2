using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialWall : Subject
{
    GameObject wall;
    // Start is called before the first frame update
    public tutorialWall()
    {
        addObserver(AchievementManager.Instance);

        wall = GameObject.FindGameObjectWithTag("wall");
    }

    // Update is called once per frame
    public void Update()
    {
        if(wall.activeInHierarchy == false)
        {
            notify(null, ObsEvent.TARGETS_DOWN);
        }
    }
}
