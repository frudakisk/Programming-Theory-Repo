using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private GameManager gameManager;

    public float speed;
    public Vector3 direction;

    private float time = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine(LifeTime(time));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

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
}
