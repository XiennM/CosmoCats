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

    private void Start()
    {
        sub_timeToIncrease = timeToIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        int rand = Random.Range(0, obstacles.Length);

        if (timeToIncrease <= 0 && maxspeed > speed)
        {
            speed = speed + (speed / 2);
            timeToIncrease = sub_timeToIncrease;
        }
        else
        {
            timeToIncrease -= Time.deltaTime;
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
