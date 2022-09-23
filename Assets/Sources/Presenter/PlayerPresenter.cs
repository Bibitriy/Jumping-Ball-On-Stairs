using UnityEngine;

public class PlayerPresenter : MonoBehaviour
{
    [SerializeField] private Transform _playerBallTransform;
    [SerializeField] private InfiniteStairView _InfiniteStairView;
    [SerializeField] private JumpMovementView _ballMovementView;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private EndGameWindowView _endGameWindowView;
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private LeaderboardView _leaderboardView;
    [SerializeField] private float _xJumpPositionOffset;
    [SerializeField] private float _yJumpPositionOffset;
    [SerializeField] private float _zJumpPositionOffset;
    [SerializeField] private float _moveXPositionBorder;
    [SerializeField] private int _topPlacesAmount;

    private MainBall _mainBall;

    private void Awake()
    {
        _mainBall = new MainBall(_xJumpPositionOffset, _yJumpPositionOffset, _zJumpPositionOffset, _playerBallTransform.position.x, _moveXPositionBorder, _topPlacesAmount);
    }

    private void OnEnable()
    {
        PlayerInput.OnSwipe += _mainBall.BallMovement.TryJumpAside;
        PlayerInput.OnTap += _mainBall.BallMovement.TryJumpForvard;
        _ballMovementView.JumpEnded += _mainBall.BallMovement.EndJump;
        _ballMovementView.JumpAsideEnded += _mainBall.BallMovement.EndSideJump;
        _mainBall.BallMovement.BallJumpStarted += _ballMovementView.JumpOnNextStair;
        _mainBall.BallMovement.BallJumpAsideStarted += _ballMovementView.JumpAside;
        _mainBall.BallMovement.BallJumpedOnNextStair += _InfiniteStairView.RelocateFirstStair;
        _mainBall.BallMovement.BallJumpedOnNextStair += _mainBall.PlayerScore.IncreaseScore;
        _collisionDetector.OnEnemyCollision += _mainBall.Die;
        _mainBall.PlayerScore.ScoreChanged += _scoreView.UpdateScore;
        _mainBall.GameStartShown += _leaderboardView.ShowLeaderboard;
        ButtonActions.NameChanged += _mainBall.PlayerScore.SetNewName;
        ButtonActions.OnSceneReload += _mainBall.PlayerScore.SaveRecord;
        MainBall.OnGameOver += _endGameWindowView.ShowEndGameWindow;
        MainBall.OnGameOver += _input.StopControlling;
    }

    private void OnDisable()
    {
        PlayerInput.OnSwipe -= _mainBall.BallMovement.TryJumpAside;
        PlayerInput.OnTap -= _mainBall.BallMovement.TryJumpForvard;
        _ballMovementView.JumpEnded -= _mainBall.BallMovement.EndJump;
        _ballMovementView.JumpAsideEnded -= _mainBall.BallMovement.EndSideJump;
        _mainBall.BallMovement.BallJumpStarted -= _ballMovementView.JumpOnNextStair;
        _mainBall.BallMovement.BallJumpAsideStarted -= _ballMovementView.JumpAside;
        _mainBall.BallMovement.BallJumpedOnNextStair -= _InfiniteStairView.RelocateFirstStair;
        _collisionDetector.OnEnemyCollision -= _mainBall.Die;
        _mainBall.BallMovement.BallJumpedOnNextStair -= _mainBall.PlayerScore.IncreaseScore;
        _mainBall.PlayerScore.ScoreChanged -= _scoreView.UpdateScore;
        _mainBall.GameStartShown -= _leaderboardView.ShowLeaderboard;
        ButtonActions.NameChanged += _mainBall.PlayerScore.SetNewName;
        ButtonActions.OnSceneReload -= _mainBall.PlayerScore.SaveRecord;
        MainBall.OnGameOver -= _endGameWindowView.ShowEndGameWindow;
        MainBall.OnGameOver -= _input.StopControlling;
    }
}
