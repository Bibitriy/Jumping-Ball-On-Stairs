using UnityEngine;

public class UIView : MonoBehaviour
{
    [SerializeField] private GameObject _endGameWindow;
    [SerializeField] private GameObject _startWindow;

    public void ShowEndGameWindow()
    {
        _endGameWindow.SetActive(true);
    }

    public void HideStartGameWindow()
    {
        _startWindow.SetActive(false);
    }
}
