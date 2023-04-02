using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boosterSpawner : MonoBehaviour
{
    public GameObject[] obstacles;

    public float timeBetweenSpawn;
    private float timeToSpawn;

    public float speed;
    public float timeToIncrease;
    public float maxspeed;

    public float timeToSpawnIncrease;
    float sub_timeToSpawnIncrease;
    public float minTimeBetweenSpawn;
    float IncSpawn;

    public int prefsCoins;
    public int boosterPercent;
    float sub_timeToIncrease;

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
        int rand = Random.Range(0, 100);
        speed = PlayerPrefs.GetFloat("Obst_speed");

        if (timeToIncrease <= 0 && maxspeed > speed)
        {
            speed = speed + (speed / 20);
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
            if (rand <= (100 - boosterPercent))
            {
                Instantiate(obstacles[Random.Range(0, prefsCoins)], transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(obstacles[Random.Range(prefsCoins, obstacles.Length)], transform.position, Quaternion.identity);
            }
            timeToSpawn = timeBetweenSpawn;
        }
        else
        {
            timeToSpawn -= Time.deltaTime;
        }
    }
}
