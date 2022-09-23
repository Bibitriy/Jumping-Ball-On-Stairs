using UnityEngine;

public class EndGameWindowView : MonoBehaviour
{
    [SerializeField] private GameObject _endGameWindow;

    public void ShowEndGameWindow()
    {
        _endGameWindow.SetActive(true);
    }
}
