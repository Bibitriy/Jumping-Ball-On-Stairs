using System;

public class BallMovement
{
    private float _xJumpPositionOffset;
    private float _yJumpPositionOffset;
    private float _zJumpPositionOffset;
    private float _currentXPosition;
    private float _leftBorder;
    private float _rightBorder;
    private bool _canMove = true;

    public Action BallJumpedOnNextStair;
    public Action<float, float> BallJumpStarted;
    public Action<float> BallJumpAsideStarted;
    public enum Direction { Right, Left }

    public BallMovement(float xJumpPositionOffset, float yJumpPositionOffset, float zJumpPositionOffset, float currentXPosition, float border)
    {
        _xJumpPositionOffset = xJumpPositionOffset;
        _yJumpPositionOffset = yJumpPositionOffset;
        _zJumpPositionOffset = zJumpPositionOffset;
        _leftBorder = -border;
        _rightBorder = border;
    }

    public void TryJumpAside(BallMovement.Direction direction)
    {
        if (_canMove)
        {
            switch (direction)
            {
                case Direction.Left:
                    if (_currentXPosition > _leftBorder)
                    {
                        _currentXPosition -= _xJumpPositionOffset;
                        BallJumpAsideStarted?.Invoke(-_xJumpPositionOffset);
                        _canMove = false;
                    }
                    break;
                case Direction.Right:
                    if (_currentXPosition < _rightBorder)
                    {
                        _currentXPosition += _xJumpPositionOffset;
                        BallJumpAsideStarted?.Invoke(_xJumpPositionOffset);
                        _canMove = false;
                    }
                    break;
            }
        }
    }

    public void TryJumpForvard()
    {
        if (_canMove)
        {
            BallJumpStarted?.Invoke(_yJumpPositionOffset, _zJumpPositionOffset);
            _canMove = false;
        }
    }

    public void EndJump()
    {
        BallJumpedOnNextStair?.Invoke();
        _canMove = true;
    }

    public void EndSideJump()
    {
        _canMove = true;
    }
}