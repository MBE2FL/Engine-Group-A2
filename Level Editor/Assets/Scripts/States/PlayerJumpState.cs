using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerJumpState : Subject, IPlayerState
{
    Movement _movement;
    Transform _playerTrans;
    Transform _camTrans;
    Rigidbody _playerRB;
    float _angle = 0.0f;
    float _movementSpeed;
    float _adrenalineBoost;
    bool firstJump = false;


    public PlayerJumpState()
    {
        addObserver(AchievementManager.Instance);
    }

    float _jumpWalkDelay = 0.0f;


    public void entry(Movement movement)
    {
        _movement = movement;
        _camTrans = Camera.main.transform;
        _playerTrans = _movement.gameObject.GetComponent<Transform>();
        _playerRB = _movement.GetComponent<Rigidbody>();
        _movementSpeed = movement.MovementSpeed;
        _adrenalineBoost = movement.AdrenalineBoost;

        _playerRB.AddForce(_playerTrans.up * _movementSpeed * _adrenalineBoost * 40.0f);

        if (!firstJump)
        {
            notify(_movement.gameObject, ObsEvent.Player_JUMPED);
            firstJump = true;
        }

    }

    public IPlayerState input()
    {
        if (_movement.OnGround)
        {

            return Movement.PlayerWalkState;
        }

        return null;
    }

    public void update()
    {
        // Camera follow player
        float horizontal = Input.GetAxis("Mouse X");
        //float vertical = Input.GetAxis("Mouse Y");


        _playerTrans.transform.Rotate(new Vector3(0.0f, horizontal * 2.0f, 0.0f));


        _angle += horizontal;


        if (EnemySpawner.AllEnemiesDead)
        {
            //camControl.stop();
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            Debug.Log("Game Over");
#else
            Application.Quit(0);
#endif
        }
    }

    public void fixedUpdate()
    {
    }
}
