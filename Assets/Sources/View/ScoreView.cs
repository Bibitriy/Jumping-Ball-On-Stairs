using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void UpdateScore(int score)
    {
        _scoreText.text = score.ToString();
    }
}
