using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayUIHandler : MonoBehaviour
{
    private GameManager gameManager;

    public TextMeshProUGUI scoreText;
    public Image ballImage;
    public TextMeshProUGUI ballsLeftText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI highscoreHolderName;

    public Sprite redBall;
    public Sprite blueBall;
    public Sprite goldBall;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + gameManager.score;
        ballsLeftText.text = "Balls Left: " + (gameManager.maxBalls - gameManager.ballCount);
        highscoreText.text = "Highscore: " + MainMenuManager.Instance.highscore;
        highscoreHolderName.text = "Holder: " + MainMenuManager.Instance.highscoreName;

        ShowBall();
    }

    private void ShowBall()
    {
        GameObject currentBall = gameManager.currentBall;
        if(currentBall == gameManager.ballPrefabs[0])
        {
            ballImage.sprite = redBall;
        }
        else if (currentBall == gameManager.ballPrefabs[1])
        {
            ballImage.sprite = blueBall;
        }
        else
        {
            ballImage.sprite = goldBall;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
