using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    [SerializeField] private float monsterSpeed = 100.0f;
    private Rigidbody rb;
    private GameManager gameManager;

    private float xBound = 50.0f;

    private int hitPoints = 3;

    public virtual int HitPoints
    {
        get { return hitPoints; }
    }
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(gameManager.gameOver && this != null)
        {
            Destroy(gameObject);
        }

        rb.AddForce(Vector3.right * monsterSpeed, ForceMode.Force);

        CheckBounds();
    }

    private void CheckBounds()
    {
        if(transform.position.x > xBound || transform.position.x < -xBound)
        {
            Destroy(gameObject);
        }
    }
}
