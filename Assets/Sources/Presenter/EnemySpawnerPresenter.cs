using UnityEngine;

public class EnemySpawnerPresenter : MonoBehaviour
{
    [SerializeField] private EnemySpawnerView _enemySpawnerView;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _border;

    private EnemiesSpawner _enemiesSpawner;

    private void Awake()
    {
        _enemiesSpawner = new EnemiesSpawner(_spawnInterval, _border);
    }

    private void Update()
    {
        _enemiesSpawner.Update();
    }

    private void OnEnable()
    {
        _enemiesSpawner.SpawnEnemy += _enemySpawnerView.SpawnEnemy;
    }

    private void OnDisable()
    {
        _enemiesSpawner.SpawnEnemy += _enemySpawnerView.SpawnEnemy;
    }
}
