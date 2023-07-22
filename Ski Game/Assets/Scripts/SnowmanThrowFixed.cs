using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanThrowFixed : MonoBehaviour
{
    public GameObject snowBall;
    public float throwDistance;
    public int throwSpeed;
    private bool justThown = false;
    private Vector3 throwY = new Vector3(0, 0.33f, 0);
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

            /* A faster method than using Vector3.Distance
           
            Vector3 offset = target.transform.position - transform.position;
            float sqrLen = offset.sqrMagnitude;
            if (sqrLen < throwDistance)
            {
                ThrowSnowball();
            }
            */


        }

    }

    private void ThrowSnowball()
    {
        justThown = true;
        GameObject tempSnowBall = Instantiate(snowBall, transform.position, transform.rotation);

        tempSnowBall.transform.position = transform.position;
        Vector3 targetDirection = Vector3.Normalize(target.transform.position - transform.position);
        //Add a small throw angle
        targetDirection += throwY;
        tempSnowBall.GetComponent<Rigidbody>().AddForce(targetDirection * throwSpeed);
        Invoke("ThrowOver", 0.5f);
    }

    void ThrowOver()
    {
        justThown = false;
    }
}
