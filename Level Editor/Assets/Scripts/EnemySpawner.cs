using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTypes
{
    Bunny,
    Zombie
}

public class EnemySpawner : MonoBehaviour
{
    


    [SerializeField]
    private int _maxEnemies = 10;
    private int _numEnemies = 0;
    [SerializeField]
    private int _spawnRate = 1;
    [SerializeField]
    private float _spawnTime = 0.5f;
    private float _currSpawnTime = 0.0f;
    [SerializeField]
    private bool _active = false;
    [SerializeField]
    private EnemyTypes _enemyType = EnemyTypes.Bunny;
    GameObject obj;

    private static List<EnemySpawner> _spawners = new List<EnemySpawner>();
    private static int _kills = 0;

    EnemyPool _enemyPool;



    public EnemyTypes EnemyType
    {
        get
        {
            return _enemyType;
        }
        set
        {
            _enemyType = value;
        }
    }

    public int MaxEnemies
    {
        get
        {
            return _maxEnemies;
        }
        set
        {
            _maxEnemies = value;
        }
    }

    public int SpawnRate
    {
        get
        {
            return _spawnRate;
        }
        set
        {
            _spawnRate = value;
        }
    }

    public float SpawnTime
    {
        get
        {
            return _spawnTime;
        }
        set
        {
            _spawnTime = value;
        }
    }

    public static bool AllEnemiesDead
    {
        get
        {
            int totalEnemies = 0;

            foreach (EnemySpawner spawner in _spawners)
            {
                if (spawner._numEnemies != spawner._maxEnemies)
                    return false;

                totalEnemies += spawner._maxEnemies;
            }

            return (_kills == totalEnemies);
        }
    }

    public static int Kills
    {
        get
        {
            return _kills;
        }
        set
        {
            _kills = value;
        }
    }

    public static void spawnersActive(bool isActive)
    {
        foreach (EnemySpawner spawner in _spawners)
        {
            spawner._active = isActive;
            spawner._numEnemies = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _spawners.Add(this);

        _enemyPool = EnemyPool.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (_active)
        {
            if ((_currSpawnTime >= _spawnTime) && (_numEnemies < _maxEnemies))
            {
                // Spawn enemy
                for (int i = 0; i < _spawnRate; ++i)
                {
                    obj = _enemyPool.getEnemy();
                    obj.transform.position = transform.position;
                    ++_numEnemies;

                    if (_numEnemies >= _maxEnemies)
                        break;
                }

                _currSpawnTime = 0.0f;
            }

            _currSpawnTime += Time.deltaTime;
        }
    }
}
