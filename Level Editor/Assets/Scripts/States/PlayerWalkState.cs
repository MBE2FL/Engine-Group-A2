using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerWalkState : IPlayerState
{
    Movement _movement;
    Transform _playerTrans;
    Transform _camTrans;
    Rigidbody _playerRB;
    float _angle = 0.0f;
    float _movementSpeed;
    float _adrenalineBoost;

    public void entry(Movement movement)
    {
        _movement = movement;
        _camTrans = Camera.main.transform;
        _playerTrans = _movement.gameObject.GetComponent<Transform>();
        _playerRB = _movement.GetComponent<Rigidbody>();
        _movementSpeed = movement.MovementSpeed;
        _adrenalineBoost = movement.AdrenalineBoost;
    }

    public IPlayerState input()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _movement.OnGround)
            return Movement.PlayerJumpState;

        return null;
    }

    public void update()
    {
        // Camera follow player
        float horizontal = Input.GetAxis("Mouse X");
        //float vertical = Input.GetAxis("Mouse Y");


        _playerTrans.transform.Rotate(new Vector3(0.0f, horizontal * 2.0f, 0.0f));


        //_cam.transform.RotateAround(_playerTrans.position, Vector3.up, horizontal);
        _angle += horizontal;


        //_camTrans.transform.position = _playerTrans.position + Quaternion.Euler(0.0f, _angle, 0.0f) * camControl.CamOffset;
        //_camTrans.transform.LookAt(_playerTrans);


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
        if (Input.GetKey(KeyCode.W))
            _playerRB.AddForce(_playerTrans.forward * _movementSpeed * _adrenalineBoost);
        if (Input.GetKey(KeyCode.S))
            _playerRB.AddForce(-_playerTrans.forward * _movementSpeed * _adrenalineBoost);
        if (Input.GetKey(KeyCode.A))
            _playerRB.AddForce(-_playerTrans.right * _movementSpeed * _adrenalineBoost);
        if (Input.GetKey(KeyCode.D))
            _playerRB.AddForce(_playerTrans.right * _movementSpeed * _adrenalineBoost);
    }
}
