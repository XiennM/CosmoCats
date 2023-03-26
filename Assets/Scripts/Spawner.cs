using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] obstacles;

    public float timeBetweenSpawn;
    private float timeToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = timeBetweenSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        int rand = Random.Range(0, obstacles.Length);

        if (timeToSpawn <= 0)
        {
            Instantiate(obstacles[rand], transform.position , Quaternion.identity);
            timeToSpawn = timeBetweenSpawn;
        }
        else
        {
            timeToSpawn -= Time.deltaTime;
        }
    }
}
