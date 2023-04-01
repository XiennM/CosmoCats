using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBoosters : MonoBehaviour
{
    float speed;
    public float radius;

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, radius).CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (PlayerPrefs.HasKey("Obst_speed"))
        {
            speed = PlayerPrefs.GetFloat("Obst_speed");
        }

        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

}
