using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hitPlayer(collision.gameObject);
        }
    }

    public virtual void hitPlayer(GameObject player)
    {
        PlayerEvents.PlayerHit();
    }
}
