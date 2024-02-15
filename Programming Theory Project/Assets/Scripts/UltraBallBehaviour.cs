using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraBallBehaviour : BallBehaviour
{
    public override float Speed
    {
        get { return 30f; }
    }

    public override int CapturePoints
    {
        get { return 15; }
    }
}
