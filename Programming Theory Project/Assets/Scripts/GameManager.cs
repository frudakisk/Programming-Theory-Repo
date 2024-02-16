using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject[] ballPrefabs;
    public GameObject[] monsterPrefabs;
    public GameObject player;
    public GameObject currentBall { get; private set; } //want others to access but not change it

    public int maxBalls = 5;
    public int ballCount;

    public int score;
    private int currentHighscore;

    public bool gameOver;

    public static float spawnRate;

    private float time = 60.0f;

    public TextMeshProUGUI timeText;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        ballCount = 0;
        currentBall = ballPrefabs[0];
        currentHighscore = MainMenuManager.Instance.highscore;
        StartCoroutine(PlayTime(time));
        StartCoroutine(SpawnMonsters(spawnRate));
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            KeyForBallSelection();

            if (Input.GetMouseButtonDown(0) && ballCount < maxBalls)
            {
                InstantiateBall();
                ballCount++;
            }
        }

        if(gameOver)
        {
            StopAllCoroutines();
            if (score > currentHighscore)
            {
                MainMenuManager.Instance.highscore = score;
            }

            gameOverPanel.SetActive(true);
        }
    }

    public void StartGame()
    {
        //for later use
    }

    /// <summary>
    /// Currently, spawns a ball at the position of my mouse click
    /// </summary>
    private void InstantiateBall()
    {
        //cast a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //Check if ray hits something
        if(Physics.Raycast(ray, out hit))
        {
            //Get the hit point and adjust the y position
            Vector3 mousePos = hit.point;
            mousePos.y = 1;

            Vector3 spawnPosition = new Vector3(player.transform.position.x, 1, player.transform.position.z);

            //make sure to change array
            GameObject ball = Instantiate(currentBall, spawnPosition, Quaternion.identity);
            shootBallInMouseDirection(ball, mousePos);
        }
        
    }

    private void shootBallInMouseDirection(GameObject ball, Vector3 mousePos)
    {
        Vector3 directionVector = mousePos - ball.transform.position;
        directionVector.Normalize();
        if(currentBall == ballPrefabs[0])
        {
            BallBehaviour ballBehaviour = ball.GetComponent<BallBehaviour>();
            ballBehaviour.direction = directionVector;

        }
        else if (currentBall == ballPrefabs[1])
        {
            GreatBallBehaviour ballBehaviour = ball.GetComponent<GreatBallBehaviour>();
            ballBehaviour.direction = directionVector;
        }
        else if (currentBall == ballPrefabs[2])
        {
            UltraBallBehaviour ballBehaviour = ball.GetComponent<UltraBallBehaviour>();
            ballBehaviour.direction = directionVector;
        }
        
    }

    private void KeyForBallSelection()
    {
        //have user select which ball to throw
        //1 is default
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Using simple ball");
            currentBall = ballPrefabs[0];
        }

        //2 is great ball
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("use great ball");
            currentBall = ballPrefabs[1];
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Using ultra ball");
            currentBall = ballPrefabs[2];
        }
    }


    //between 18 and 5 on z axis we should spawn monsters
    IEnumerator SpawnMonsters(float spawnRate)
    {
        while(!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            //create spawn location on random z between 5 and 18
            //initialize a random monster at every set interval
            float zSpawn = Random.Range(-18, 5);
            int index = Random.Range(0, monsterPrefabs.Length);
            Vector3 spawnPos = new Vector3(-50, 1, zSpawn);
            Instantiate(monsterPrefabs[index], spawnPos, Quaternion.identity);
        }
    }

    IEnumerator PlayTime(float time)
    {
        float remainingTime = time;
        while(remainingTime >= 0)
        {
            UpdateTimer(remainingTime, timeText);
            yield return new WaitForSeconds(1.0f);
            remainingTime--;
        }
        gameOver = true;
    }

    private void UpdateTimer(float time, TextMeshProUGUI timeText)
    {
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = (time % 60).ToString("00");
        timeText.text = "Time: " + minutes + ":" + seconds;
    }
}
