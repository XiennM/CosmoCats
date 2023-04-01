using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{

    float speed;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("Obst_speed"))
        {
            speed = PlayerPrefs.GetFloat("Obst_speed");
        }

        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
