using UnityEngine;

public class EnemySpawnerPresenter : MonoBehaviour
{
    [SerializeField] private EnemySpawnerView _enemySpawnerView;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _border;

    private bool _isGameRunning = false;
    private EnemiesSpawner _enemiesSpawner;

    private void Awake()
    {
        _enemiesSpawner = new EnemiesSpawner(_spawnInterval, _border);
    }

    private void Update()
    {
        if (_isGameRunning)
        {
            _enemiesSpawner.Update();
        }
    }

    public void StartGame()
    {
        _isGameRunning = true;
    }

    private void OnEnable()
    {
        _enemiesSpawner.SpawnEnemy += _enemySpawnerView.SpawnEnemy;
        PlayerInput.OnGameStart += StartGame;
    }

    private void OnDisable()
    {
        _enemiesSpawner.SpawnEnemy -= _enemySpawnerView.SpawnEnemy;
        PlayerInput.OnGameStart -= StartGame;
    }
}
