using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleExplode : Obstacle
{

    public override void hitPlayer(GameObject player)
    {
        //temporary to show behavior
        Destroy(gameObject);

    }
}
