using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private GameManager gameManager;

    private float speed = 10f;
    private int capturePoints = 15;

    public Vector3 direction;

    private float time = 5.0f;

    public virtual float Speed
    {
        get { return speed; }
    }

    public virtual int CapturePoints
    {
        get { return capturePoints; }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine(LifeTime(time));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Speed * Time.deltaTime);
    }

    /// <summary>
    /// Create a timer for how long the ball should exist
    /// </summary>
    /// <param name="time">the amount of time the ball should exist</param>
    /// <returns>a coroutine</returns>
    private IEnumerator LifeTime(float time)
    {
        float remainingTime = time;
        while(remainingTime >= 0)
        {
            yield return new WaitForSeconds(1.0f);
            remainingTime -= 1.0f;
        }

        Destroy(gameObject);
        gameManager.ballCount--;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if we hit a monster, add ball specific points to score
        if(other.gameObject.CompareTag("Monster"))
        {
            gameManager.score += CapturePoints;
            gameManager.score += other.GetComponent<MonsterBehaviour>().HitPoints;
            Destroy(other.gameObject);
        }
        gameManager.ballCount--;
        Destroy(gameObject);
    }


}
