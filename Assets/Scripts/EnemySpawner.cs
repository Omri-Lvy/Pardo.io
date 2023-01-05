using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : Component
{
    private GameObject _enemy;
    private float _enemyInterval;
    private float _counter;
    private int _max;

    private IEnumerator spawnEnemy()
    {
        if (_counter++ < _max)
        {
            yield return new WaitForSeconds(_enemyInterval);
            Instantiate(_enemy, new Vector3(Random.Range(-5f,5f), Random.Range(-6f,6f), 0), Quaternion.identity);
        }
    }

    public EnemySpawner(GameObject enemy, float interval,int max)
    {
        _enemy = enemy;
        _enemyInterval = interval;
        _counter = 0;
        _max = max;
    }
}
