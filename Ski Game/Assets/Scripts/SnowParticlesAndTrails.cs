using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowParticlesAndTrails : MonoBehaviour
{
    public GameObject snowParticles;

    public GameObject leftTrail, rightTrail;

    public Transform groundCheck;

    public LayerMask groundLayers;

    public PlayerController playerControllerScript;

    private void Update()
    {
        bool onGround = Physics.Linecast(transform.position, groundCheck.position, groundLayers);

        if (onGround)
        {
            leftTrail.GetComponent<TrailRenderer>().emitting = true;
            rightTrail.GetComponent<TrailRenderer>().emitting = true;
            if (playerControllerScript.playerStats.speed > 1000)
            {
                snowParticles.SetActive(true);
            }
            else
            {
                snowParticles.SetActive(false);
            }
        }
        else
        {
            leftTrail.GetComponent<TrailRenderer>().emitting = false;
            rightTrail.GetComponent<TrailRenderer>().emitting = false;
            snowParticles.SetActive(false);
        }
    }
}