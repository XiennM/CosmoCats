using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] obstacles;

    public float timeBetweenSpawn;
    private float timeToSpawn;

    public float speed;
    public float timeToIncrease;
    public float maxspeed;
    float sub_timeToIncrease;

    public float timeToSpawnIncrease;
    float sub_timeToSpawnIncrease;
    public float minTimeBetweenSpawn;
    float IncSpawn;

    private void Start()
    {
        sub_timeToIncrease = timeToIncrease;
        sub_timeToSpawnIncrease = timeToSpawnIncrease;
        PlayerPrefs.SetFloat("Obst_speed", speed);
        IncSpawn = timeBetweenSpawn / 20;
    }

    // Update is called once per frame
    void Update()
    {
        int rand = Random.Range(0, obstacles.Length);
        speed = PlayerPrefs.GetFloat("Obst_speed");

        if (timeToIncrease <= 0 && maxspeed > speed)
        {
            speed *= 1.05f;
            timeToIncrease = sub_timeToIncrease;
        }
        else
        {
            timeToIncrease -= Time.deltaTime;
        }
        
        if (timeToSpawnIncrease <= 0 && timeBetweenSpawn > minTimeBetweenSpawn)
        {
            timeBetweenSpawn -= IncSpawn;
            timeToSpawnIncrease = sub_timeToSpawnIncrease;
        }
        else
        {
            timeToSpawnIncrease -= Time.deltaTime;
        }
        
        PlayerPrefs.SetFloat("Obst_speed", speed);

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
