using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject player;
    public GameObject[] OffObj;
    public GameObject button;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            button.transform.position = new Vector3(0, player.transform.position.y, 0);
            player.SetActive(false);
            foreach (var item in OffObj)
                item.SetActive(false);

        }
    }
}
