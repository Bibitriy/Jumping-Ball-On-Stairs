using UnityEngine;

public class EnemyPresenter : MonoBehaviour
{
    [SerializeField] private JumpMovementView _jumpMovementView;
    [SerializeField] private float _yJumpOffset;
    [SerializeField] private float _zJumpOffset;
    [SerializeField] private float _secondsBetweenJumps;

    private Enemy _enemy;

    private void Awake()
    {
        _enemy = new Enemy(_yJumpOffset, _zJumpOffset, _secondsBetweenJumps);
    }

    private void Update()
    {
        _enemy.Update();
    }

    private void OnEnable()
    {
        _enemy.Jump += _jumpMovementView.JumpOnNextStair;
    }

    private void OnDisable()
    {
        _enemy.Jump += _jumpMovementView.JumpOnNextStair;
    }
}