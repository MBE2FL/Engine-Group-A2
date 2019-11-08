using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : IObserver
{
    static AchievementManager _instance;

    public static AchievementManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AchievementManager();
            }

            return _instance;
        }
    }

    public void onNotify(GameObject obj, ObsEvent _event)
    {
        switch (_event)
        {
            case ObsEvent.TEST_EVENT:
                break;
            case ObsEvent.ENEMY_DIED:
                Debug.Log("Enemy Died");
                enemyDied();
                break;
            default:
                break;
        }
    }

    private AchievementManager()
    {

    }

    void enemyDied()
    {
        ++EnemySpawner.Kills;
        Debug.Log("Kills: " + EnemySpawner.Kills);
    }
}
