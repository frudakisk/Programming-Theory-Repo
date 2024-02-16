using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonDifficulty : MonoBehaviour
{
    private Button button;
    public float spawnRate;
    public TextMeshProUGUI playerName;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        MainMenuManager.Instance.username = playerName.text;
        GameManager.spawnRate = spawnRate;
        SceneManager.LoadScene(1);
    }
}
