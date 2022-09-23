using System.Collections.Generic;
using UnityEngine;

public class InfiniteStairView : MonoBehaviour
{
    [SerializeField] private GameObject _stepPrefab;
    [SerializeField] private Vector3 _nextStepOffset;
    [SerializeField] private int _amountOfVisibleSteps;

    private Queue<GameObject> _stepsQueue = new Queue<GameObject>();
    private List<GameObject> _spawnedSteps;
    private Vector3 _nextStepPosition = Vector3.zero;

    private void Awake()
    {
        SpawnStartStairs();
    }

    private void SpawnStartStairs()
    {
        _spawnedSteps = new List<GameObject>(_amountOfVisibleSteps);
        for (int i = 0; i < _amountOfVisibleSteps; i++)
        {
            _spawnedSteps.Add(Instantiate(_stepPrefab, _nextStepPosition, _stepPrefab.transform.rotation));
            _stepsQueue.Enqueue(_spawnedSteps[i]);
            _nextStepPosition += _nextStepOffset;
        }
    }

    public void RelocateFirstStair()
    {
        var newStep = _stepsQueue.Dequeue();
        newStep.transform.position = _nextStepPosition;
        _stepsQueue.Enqueue(newStep);
        _nextStepPosition += _nextStepOffset;
    }

    public Vector3 GetLastStairPosition()
    {
        return _nextStepPosition;
    }
}
