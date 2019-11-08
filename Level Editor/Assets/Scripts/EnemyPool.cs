using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : Subject
{
    [SerializeField]
    int _poolSize = 40;
    Queue<GameObject> _enemyPool;
    Factory _factory;
    static EnemyPool _instance;


    public static EnemyPool Instance
    {
        get
        {
            if (_instance == null)
                _instance = new EnemyPool();

            return _instance;
        }
    }


    private EnemyPool()
    {
        _enemyPool = new Queue<GameObject>(_poolSize);
        _factory = Factory.Instance;

        GameObject enemy;

        for (int i = 0; i < _poolSize; ++i)
        {
            _factory.CreateGameObject(ObjectTypes.Bunny, out enemy);
            enemy.SetActive(false);
            _enemyPool.Enqueue(enemy);
        }

        addObserver(AchievementManager.Instance);
    }


    public GameObject getEnemy()
    {
        GameObject obj = null;

        if (_enemyPool.Count > 0)
        {
            obj = _enemyPool.Dequeue();
            obj.SetActive(true);
        }

        return obj;
    }

    public void recycleEnemy(GameObject enemy)
    {
        if (enemy && (_enemyPool.Count < _poolSize))
        {
            enemy.SetActive(false);

            _enemyPool.Enqueue(enemy);

            notify(enemy, ObsEvent.ADRENALINE_RUSH);
        }
    }
}
