using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public List<Transform> spawnPoints = new List<Transform>();
    public List<GameObject> spawnObject = new List<GameObject>();

    public float spawnTime=1;
    private float currentSpawnTime = 0;
    public int maxObjects = 10;
    private int currentObjects;

    private void Update()
    {
        if (currentObjects < maxObjects)
        {
            if(currentSpawnTime>=spawnTime)
            {
                GameObject selectedObject = spawnObject[Random.Range(0, spawnObject.Count)];
                Transform selectedPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
                Instantiate(selectedObject, selectedPoint.position, Quaternion.identity);
                currentSpawnTime = 0;
                currentObjects++;
            }
            else
            {
                currentSpawnTime += Time.deltaTime;
            }
        }
    }
}


