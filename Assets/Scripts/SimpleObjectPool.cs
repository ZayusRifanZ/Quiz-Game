using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPool : MonoBehaviour
{
    public GameObject prefabs;

    private Stack<GameObject> inactiveInstances = new Stack<GameObject>();

    public GameObject GetObject()
    {
        GameObject spawnedGameObject;

        if(inactiveInstances.Count > 0)
        {
            spawnedGameObject = inactiveInstances.Pop();
        }
        else
        {
            spawnedGameObject = (GameObject)GameObject.Instantiate(prefabs);

            //add pooled object
            PooledObject poolObject = spawnedGameObject.AddComponent<PooledObject>();
            poolObject.pool = this;
        }
        spawnedGameObject.transform.SetParent(null);
        spawnedGameObject.SetActive(true);
        return spawnedGameObject;
    }

    public void ReturnObject(GameObject toReturn)
    {
        PooledObject pooledObject = toReturn.GetComponent<PooledObject>();

        if(pooledObject != null && pooledObject.pool == this)
        {
            toReturn.transform.SetParent(transform);
            toReturn.SetActive(false);

            inactiveInstances.Push(toReturn);
        }
        else
        {
            Debug.LogWarning(toReturn.name + "was to returned to a pool it wasn't spawned from! Destroying. ");
            Destroy(toReturn);
        }
    }

    
}
//a component that simply identifies the pool that GameObject came from
public class PooledObject : MonoBehaviour
{
    public SimpleObjectPool pool;
}
