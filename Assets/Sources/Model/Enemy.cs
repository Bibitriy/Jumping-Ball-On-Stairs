using System;
using UnityEngine;

public class Enemy
{
    [SerializeField] private float _yJumpOffset;
    [SerializeField] private float _zJumpOffset;
    private float _secondsBetweenJumps;
    private float _lastJumpTime;

    public Action<float, float> Jump;

    public void Update()
    {
        if (Time.time - _lastJumpTime >= _secondsBetweenJumps)
        {
            _lastJumpTime = Time.time;
            Jump?.Invoke(_yJumpOffset, _zJumpOffset);
        }
    }

    public Enemy(float yJumpDirection, float zJumpDirection, float secondsBetweenJumps)
    {
        _yJumpOffset = yJumpDirection;
        _zJumpOffset = zJumpDirection;
        _secondsBetweenJumps = secondsBetweenJumps;
    }
}
