using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{

    private Vector2 fingerCurPos;
    private Vector2 fingerTargetPos;
    private Vector2 targetPos;
    public int columnNum = 0;
    public float speed;
    float Xincrement;

    public GameObject Wasted_window;
    public GameObject score;



    private void Start()
    {
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Camera.main.aspect;
        Xincrement = width / 3;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Began)
        {
            fingerCurPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Ended)
        {
            fingerTargetPos = Input.GetTouch(0).position;

            if (fingerTargetPos.x > fingerCurPos.x && columnNum != 1)
            {
                MoveRight();
            }

            if (fingerTargetPos.x < fingerCurPos.x && columnNum != -1)
            {
                MoveLeft();
            }
        }

    }

    public void MoveRight()
    {
        columnNum++;
        targetPos = new Vector2(transform.position.x + Xincrement, transform.position.y);
    }
    public void MoveLeft()
    {
        columnNum--;
        targetPos = new Vector2(transform.position.x - Xincrement, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Wasted_window.SetActive(true);
            score.SetActive(false);
        }
    }

}
