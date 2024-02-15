using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] ballPrefabs;
    public GameObject player;
    private GameObject currentBall;

    private int maxBalls = 5;
    public int ballCount;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        ballCount = 0;
        currentBall = ballPrefabs[0];
    }

    // Update is called once per frame
    void Update()
    {
        KeyForBallSelection();

        if (Input.GetMouseButtonDown(0) && ballCount < maxBalls)
        {
            InstantiateBall();
            ballCount++;
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

    
}
