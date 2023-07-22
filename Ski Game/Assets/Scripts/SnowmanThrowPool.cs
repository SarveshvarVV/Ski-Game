using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanThrowPool : MonoBehaviour
{
    public GameObject snowBall;
    public float throwDistance;
    private bool justThown = false;
    private int frameInterval = 5;
    private GameObject target;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.frameCount % frameInterval == 0)
        {
            float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

            if (distanceToTarget < throwDistance && justThown == false)
            {
                ThrowSnowball();
            }
        }

    }

    private void ThrowSnowball()
    {
        justThown = true;
        GameObject tempSnowBall = ObjectPool.instance.GetObject();


        if (tempSnowBall != null)
        {
            tempSnowBall.SetActive(true);
            tempSnowBall.transform.position = transform.position;
            Vector3 targetDirection = Vector3.Normalize(target.transform.position - transform.position);
            //Add a small throw angle
            targetDirection += new Vector3(0, 0.33f, 0);
            tempSnowBall.GetComponent<Rigidbody>().AddForce(targetDirection * 1250);
            Invoke("ThrowOver", 0.5f);
        }
    }

    void ThrowOver()
    {
        justThown = false;
    }
}
