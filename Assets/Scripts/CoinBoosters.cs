using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBoosters : MonoBehaviour
{
    float speed;
    public float radius;
    public bool ableToReach = false;

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, radius).CompareTag("Obstacle"))
        {
            if (!ableToReach)
            {
                Destroy(gameObject);
            }
        }

        if (PlayerPrefs.HasKey("Obst_speed"))
        {
            speed = PlayerPrefs.GetFloat("Obst_speed");
        }

        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

}
