using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool instance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int numToPool;
    public bool growPool;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        pooledObjects = new List<GameObject>();

        for(int i = 0; i < numToPool; i++)
        {
            GameObject obj = (GameObject) Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        //should we add objects to our pool if needed
        if (growPool)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            numToPool++;
            pooledObjects.Add(obj);
            return obj;
        }
        else
        {
            return null;
        }
    }
}
