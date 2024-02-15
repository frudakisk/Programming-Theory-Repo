using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject ballPrefab;
    public GameObject player;

    private int maxBalls = 5;
    public int ballCount;

    // Start is called before the first frame update
    void Start()
    {
        ballCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0) && ballCount < maxBalls)
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

            GameObject ball = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
            shootBallInMouseDirection(ball, mousePos);
        }
        
    }

    private void shootBallInMouseDirection(GameObject ball, Vector3 mousePos)
    {
        Vector3 directionVector = mousePos - ball.transform.position;
        directionVector.Normalize();
        BallBehaviour ballBehaviour = ball.GetComponent<BallBehaviour>();
        ballBehaviour.direction = directionVector;
    }

    
}
