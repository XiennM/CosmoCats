using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    public float speed;
    public int[] position = new int[2] { 0, 0 };
    public GameObject[] move_with_player;


    void Start()
    {

    }
    void Update()
    {
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;

        foreach (var x in move_with_player)
        x.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        //    x.GetComponent<Transform>().position = new Vector3(0, transform.position.y + 1.5f, 0);
    }

    public void MoveRight()
    {
        if (position[0] == 0)
        {
            transform.position += new Vector3(0.7f, 0, 0);
            if (position[1] == 1)
                position[0] = 0;
            else
                position[0] = 1;
            position[1] = 0;
        }
    }
    public void MoveLeft()
    {
        if (position[1] == 0)
        {
            transform.position += new Vector3(-0.7f, 0, 0);
            if (position[0] == 1)
                position[1] = 0;
            else
                position[1] = 1;
            position[0] = 0;
        }
    }
}
