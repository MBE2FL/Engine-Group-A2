using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _hp = 100;
    EnemyPool _enemyPool;

    public int HP
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
        }
    }

    private void Start()
    {
        _enemyPool = EnemyPool.Instance;
    }

    private void Update()
    {
        if (_hp <= 0)
        {
            //Destroy(gameObject);
            _enemyPool.recycleEnemy(gameObject);

            //++EnemySpawner.Kills;
            //Debug.Log("Kills: " + EnemySpawner.Kills);
        }
    }
}
