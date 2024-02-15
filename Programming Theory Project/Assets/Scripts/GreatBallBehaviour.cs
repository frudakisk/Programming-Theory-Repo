using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatBallBehaviour : BallBehaviour
{
    public override float Speed
    {
        get { return 20f; }
    }

    public override int CapturePoints
    {
        get { return 10; }
    }

}
