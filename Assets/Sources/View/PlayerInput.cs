using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _minDistanceForSwipe = 20f;
    [SerializeField] private float _tapTime = 0.1f;

    private Vector2 _fingerDownPosition;
    private Vector2 _fingerUpPosition;
    private float _touchStartTime;
    private bool _isSwiped = false;
    private bool _isGameRunning = true;
    
    public static event Action<BallMovement.Direction> OnSwipe;
    public static event Action OnTap;

    private void Update()
    {
        if (_isGameRunning)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    _fingerUpPosition = touch.position;
                    _fingerDownPosition = touch.position;
                    _touchStartTime = Time.time;
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    _fingerDownPosition = touch.position;
                    DetectSwipe();
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    _fingerDownPosition = touch.position;
                    _isSwiped = false;
                    DetectTouch();
                }
            }
        }
    }

    public void StopControlling()
    {
        _isGameRunning = false;
    }

    private void DetectSwipe()
    {
        if (!_isSwiped && SwipeDistanceCheckMet())
        {
            var direction = _fingerDownPosition.x - _fingerUpPosition.x > 0 ? BallMovement.Direction.Right : BallMovement.Direction.Left;
            OnSwipe(direction);
            _isSwiped = true;
            _fingerDownPosition = _fingerUpPosition;
        }
    }

    private bool SwipeDistanceCheckMet()
    {
        return HorizontalMovementDistance() > _minDistanceForSwipe;
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(_fingerDownPosition.x - _fingerUpPosition.x);
    }

    private void DetectTouch()
    {
        if (Time.time - _touchStartTime < _tapTime)
        {
            OnTap?.Invoke();
        }
    }
}
