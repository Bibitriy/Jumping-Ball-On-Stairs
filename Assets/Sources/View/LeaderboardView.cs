using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textLabelPrefab;
    [SerializeField] private Transform _parentOfPlayersList;
    [SerializeField] private Vector3 _labelOffset;
    [SerializeField] private float _labelsGape;

    private Vector3 _currentLabelPosition;

    public void ShowLeaderboard(List<LeaderboardPlace> leaderboardPlaces)
    {
        _currentLabelPosition = _labelOffset;
        for (int i = 0; i < leaderboardPlaces.Count; i++)
        {
            TextMeshProUGUI thisLabel = Instantiate(_textLabelPrefab, _currentLabelPosition, _textLabelPrefab.transform.rotation, _parentOfPlayersList);
            thisLabel.text = (i + 1).ToString() + "st Place : " + leaderboardPlaces[i].Name + "  " + leaderboardPlaces[i].Score;
            _currentLabelPosition.y -= _labelsGape;
        }
    }
}
