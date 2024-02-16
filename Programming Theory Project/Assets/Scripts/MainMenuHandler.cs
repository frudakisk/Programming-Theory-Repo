using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuHandler : MonoBehaviour
{
    public TextMeshProUGUI currentHighscoreText;
    public GameObject howToPlayPanel;

    private void Start()
    {
        currentHighscoreText.text = "Current Highscore: " + MainMenuManager.Instance.highscoreName + ": " + MainMenuManager.Instance.highscore;
    }


    public void QuitGame()
    {
        MainMenuManager.Instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ToggleHowToPlayPanel()
    {
        howToPlayPanel.SetActive(!howToPlayPanel.activeSelf);
    }
}
