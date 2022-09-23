using System;
using UnityEngine;

public class EnemiesSpawner
{
    private float _enemySpawnInterval;
    private float _lastTimeEnemySpawn;
    private float _leftBorder;
    private float _rightBorder;

    public Action<float> SpawnEnemy;

    public void Update()
    {
        if (Time.time - _lastTimeEnemySpawn >= _enemySpawnInterval)
        {
            SpawnEnemyOnRandomTrack();
            _lastTimeEnemySpawn = Time.time;
        }
    }

    public EnemiesSpawner(float enemySpawnInterval, float border)
    {
        _enemySpawnInterval = enemySpawnInterval;
        _lastTimeEnemySpawn = enemySpawnInterval;
        _leftBorder = -border;
        _rightBorder = border;
    }

    public void SpawnEnemyOnRandomTrack()
    {
        float randomTrackPositionNumber = UnityEngine.Random.Range(_leftBorder, _rightBorder);
        SpawnEnemy?.Invoke(randomTrackPositionNumber);
    }
}
