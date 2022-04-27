using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyerFlip : MonoBehaviour
{

    public AIPath aiPath;

    public float scaleX;
    public float scaleY;
    public bool versLaDroite;

    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-scaleX, scaleY, 1f);
            versLaDroite = true;
        }else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(scaleX, scaleY, 1f);
            versLaDroite = false;
        }
    }
}
