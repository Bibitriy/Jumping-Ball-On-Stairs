using UnityEngine;

public class EnemySpawnerView : MonoBehaviour
{
    [SerializeField] private InfiniteStairView _infiniteStairView;
    [SerializeField] private Vector3 _startSpawnOffset;
    [SerializeField] private EnemyPresenter _enemyPrefab;

    public void SpawnEnemy(float xPosition)
    {
        Instantiate(_enemyPrefab, _infiniteStairView.GetLastStairPosition() + _startSpawnOffset + Vector3.right* xPosition, _enemyPrefab.transform.rotation);
    }
}
