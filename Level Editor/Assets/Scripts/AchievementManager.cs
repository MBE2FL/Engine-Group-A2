using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : IObserver
{
    static AchievementManager _instance;

    Movement _playerMovement;
    GameObject _target1;
    GameObject _target2;

    [SerializeField]
    private int _killStreak = 10;

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
            case ObsEvent.PLAYER_MOVED:
                Debug.Log("You moved... Nice");
                PlayerMoved();
                break;
            case ObsEvent.TARGETS_DOWN:
                Debug.Log("You learned to shoot... Nice");
                TargetsDown();
                break;
            case ObsEvent.Player_JUMPED:
                Debug.Log("You learned to jump... Nice");
                PlayerJumped();
                break;
            case ObsEvent.TUTORIAL_DONE:
                Debug.Log("Your now a bunny killer... Nice");
                TutorialDone();
                break;
            case ObsEvent.GAME_BEGINS:
                Debug.Log("Let your Hatred consume you");
                GameBegins();
                break;
            case ObsEvent.ADRENALINE_RUSH:
                Debug.Log("Adrenaline Rush Activate, Your a monster!");
                AdrenalineRush();
                break;
            default:
                break;
        }
    }

    private AchievementManager()
    {
        
        
    }

    void PlayerMoved()
    {

    }

    void TargetsDown()
    {

    }

    void PlayerJumped()
    {

    }

    void TutorialDone()
    {

    }

    void GameBegins()
    {

    }

    void AdrenalineRush()
    {
        _playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();

        ++EnemySpawner.Kills;
        Debug.Log("Kills: " + EnemySpawner.Kills);

        if ((EnemySpawner.Kills % _killStreak) == 0)
            _playerMovement.setAdrenalineRush(true);
    }
}
