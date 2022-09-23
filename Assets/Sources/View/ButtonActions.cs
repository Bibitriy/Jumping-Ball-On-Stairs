using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    public static Action<string> NameChanged;
    public static Action OnSceneReload;

    public void SaveName()
    {
        NameChanged?.Invoke(_inputField.text);
    }

    public void ReloadScene()
    {
        OnSceneReload?.Invoke();
        StartCoroutine(ReloadAfterEndOfFrame());
    }

    private IEnumerator ReloadAfterEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}