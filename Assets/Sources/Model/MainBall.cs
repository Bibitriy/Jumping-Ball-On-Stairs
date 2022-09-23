using System;
using System.Collections.Generic;

public class MainBall
{
    private BallMovement _ballMovement;
    private PlayerScore _playerScore;

    public BallMovement BallMovement => _ballMovement;
    public PlayerScore PlayerScore => _playerScore;
    public static Action OnGameOver;
    public Action<List<LeaderboardPlace>> GameStartShown;

    public MainBall(float xJumpPositionOffset, float yJumpPositionOffset, float zJumpPositionOffset, float currentPosition, float border, int topPlacesAmount)
    {
        _ballMovement = new BallMovement(xJumpPositionOffset, yJumpPositionOffset, zJumpPositionOffset, currentPosition, border);
        _playerScore = new PlayerScore(topPlacesAmount);
    }

    public void Die()
    {
        _playerScore.ScoreCountEnded();
        OnGameOver?.Invoke();
        GameStartShown?.Invoke(_playerScore.GetLeaderboard());
    }
}
