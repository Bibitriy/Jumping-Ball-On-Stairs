using System;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerScore
{
    private LeaderboardPlace _currentLeaderboardPlace;
    private int _placesAmount;
    private int _playerScore = 0;

    public Action<int> ScoreChanged;

    public PlayerScore(int topPlacesAmount)
    {
        _placesAmount = topPlacesAmount;
        _currentLeaderboardPlace = new LeaderboardPlace();
    }

    public void ScoreCountEnded()
    {
        _currentLeaderboardPlace = new LeaderboardPlace("Player", _playerScore);
    }

    public void SetNewName(string newName)
    {
        _currentLeaderboardPlace.SetName(newName);
    }

    public void SaveRecord()
    {
        _currentLeaderboardPlace.SaveScore(_placesAmount);
    }

    public List<LeaderboardPlace> GetLeaderboard()
    {
        List<LeaderboardPlace> leaderboard = new List<LeaderboardPlace>();
        for (int  i = 1; i <= _placesAmount; i++)
        {
            string name = PlayerPrefs.GetString(i.ToString() + "name");
            int score = PlayerPrefs.GetInt(i.ToString());
            leaderboard.Add(new LeaderboardPlace(name, score));
        }
        return leaderboard;
    }

    public void IncreaseScore()
    {
        _playerScore++;
        ScoreChanged?.Invoke(_playerScore);
    }
}
