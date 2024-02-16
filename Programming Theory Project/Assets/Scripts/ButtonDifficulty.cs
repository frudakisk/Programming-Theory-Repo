using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonDifficulty : MonoBehaviour
{
    private Button button;
    public float spawnRate;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        GameManager.spawnRate = spawnRate;
        SceneManager.LoadScene(1);
    }
}
