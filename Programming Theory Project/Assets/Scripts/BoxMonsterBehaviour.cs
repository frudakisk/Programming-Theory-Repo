using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMonsterBehaviour : MonsterBehaviour
{
    public override int HitPoints
    {
        get { return 5; }
    }

    public override void Start()
    {
        base.Start();
        StartCoroutine(ChangeSize());
    }

    IEnumerator ChangeSize()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1,20));
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            yield return new WaitForSeconds(Random.Range(1, 20));
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    
}
