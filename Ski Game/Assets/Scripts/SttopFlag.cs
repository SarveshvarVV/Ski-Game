using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SttopFlag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameEvents.StopRace();
        }
    }
}
