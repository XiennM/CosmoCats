using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Move : MonoBehaviour
{

    private Vector2 fingerCurPos;
    private Vector2 fingerTargetPos;
    private Vector2 targetPos;
    public int columnNum = 0;
    public float speed;
    float Xincrement;
    public float radius;
    private Vector3 velocity;

    public GameObject Wasted_window;
    public Text score;
    public Text pause_score;
    public GameObject score_counter;
    public GameObject scoreMain;

    private bool isMagnet = false;
    public float CoolDownTime;
    private float curMagnetCoolDownTime;
    public GameObject magnet;

    private bool isShield = false;
    private float curShieldCoolDownTime;
    public GameObject shield;

    public GameObject spawner;
    public GameObject boosterSpawner;
    public float spawnerSpeed;
    public float boosterSpeed;

    public float minSpeed;

    public AudioSource coinSound;
    public AudioSource boosterSound;
    public AudioSource obstacleSound;

    private Animator camAnim;

    public bool isPaused = false;
    public bool isResumed = false;

    float timeToResume = 0.5f;

    private void Start()
    {
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Camera.main.aspect;
        Xincrement = width / 3;
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    void Update()
    {

        if (isResumed)
        {
            timeToResume -= Time.deltaTime;
            if (timeToResume < 0)
            {
                isResumed = false;
                timeToResume = 0.5f;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                fingerCurPos = Input.GetTouch(0).position;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                fingerTargetPos = Input.GetTouch(0).position;

                if (fingerTargetPos.x > fingerCurPos.x && columnNum != 1)
                {
                    if (!isPaused && !isResumed)
                        MoveRight();
                }

                if (fingerTargetPos.x < fingerCurPos.x && columnNum != -1)
                {
                    if (!isPaused && !isResumed)
                        MoveLeft();
            }
            }

            if (isMagnet)
            {

                MagnetMove();

                if (curMagnetCoolDownTime <= 0)
                {
                    isMagnet = false;
                    magnet.SetActive(false);
                }
                else
                {
                    curMagnetCoolDownTime -= Time.deltaTime;
                }
            }

            if (isShield)
            {
                if (curShieldCoolDownTime <= 0)
                {
                    isShield = false;
                    shield.SetActive(false);
                }
                else
                {
                    curShieldCoolDownTime -= Time.deltaTime;
                }
            }

        pause_score.text = score_counter.GetComponent<Text>().text;
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
            if (!isShield)
            {
                obstacleSound.Play();
                camAnim.SetTrigger("shake");
                Wasted_window.SetActive(true);
                score.text = score_counter.GetComponent<Text>().text;
                score_counter.SetActive(false);
                scoreMain.SetActive(false);
                gameObject.SetActive(false);
                if (int.Parse(score.text) > PlayerPrefs.GetInt("SaveScore"))
                    PlayerPrefs.SetInt("SaveScore", int.Parse(score.text));
            }
            else
            {
                isShield = false;
                shield.SetActive(false);
            }
        }

        if (collision.CompareTag("Coin"))
        {
            coinSound.Play();
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Magnet"))
        {
            boosterSound.Play();
            curMagnetCoolDownTime = CoolDownTime;
            isMagnet = true;
            Destroy(collision.gameObject);
            magnet.SetActive(true);
        }

        if (collision.CompareTag("Shield"))
        {
            boosterSound.Play();
            curShieldCoolDownTime = CoolDownTime;
            isShield = true;
            Destroy(collision.gameObject);
            shield.SetActive(true);
        }

        if (collision.CompareTag("CoinBag"))
        {
            boosterSound.Play();
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + Random.Range(10, 20));
            Destroy(collision.gameObject);
        }
        
        if (collision.CompareTag("SlowDown"))
        {
            boosterSound.Play();
            spawner.GetComponent<Spawner>().timeBetweenSpawn = spawnerSpeed;
            boosterSpawner.GetComponent<boosterSpawner>().timeBetweenSpawn = boosterSpeed;
            PlayerPrefs.SetFloat("Obst_speed", minSpeed);
            Destroy(collision.gameObject);
        }
        
    }

    public void MagnetMove()
    {
        Collider2D[] coins = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D coin in coins) 
        {
            if (coin.gameObject.CompareTag("Coin"))
            {
                coin.gameObject.GetComponent<CoinBoosters>().ableToReach = true;
                coin.gameObject.transform.position = Vector3.SmoothDamp(coin.gameObject.transform.position, new Vector3(transform.position.x, transform.position.y, 0), ref velocity, Vector3.Distance(transform.position, coin.transform.position) / 3f);
            }
        }
    }

}
