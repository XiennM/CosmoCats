using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    public GameObject Menu;
    public GameObject Gallery;
    public GameObject ComicsChapters;
    public Text highScore;
    private int h_score;
    public Text coinCounter;
    private int coins;
    public  AudioSource click_audio;
    public GameObject cat;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("CatSkin")) PlayerPrefs.SetInt("CatSkin", 0);
        if (!PlayerPrefs.HasKey("RocketSkin")) PlayerPrefs.SetInt("RocketSkin", 0);
        instance = this;
        if (PlayerPrefs.HasKey("SaveScore"))
            h_score = PlayerPrefs.GetInt("SaveScore");
        else h_score = 0;
        if (PlayerPrefs.HasKey("Coins"))
            coins = PlayerPrefs.GetInt("Coins");
        else coins = 0;
    }


    private void Start()
    {
        if (Score_script.High_score > h_score)
        {
            h_score = Score_script.High_score;
            PlayerPrefs.SetInt("SaveScore", h_score);
        }
        instance.highScore.text = h_score.ToString();
        instance.coinCounter.text = coins.ToString();
        Gallery.SetActive(false);
        ComicsChapters.SetActive(false);
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds((float)0.2);
    }

    public void NewGame()
    {
        StartCoroutine(waiter());
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        StartCoroutine(waiter());
        Application.Quit();
    }
    public void Collection()
    {
        StartCoroutine(waiter());
        cat.GetComponent<Animator>().Rebind();
        cat.GetComponent<Animator>().Update(0f);
        Menu.SetActive(false);
        Gallery.SetActive(true);
    }
    public void Comics()
    {
        StartCoroutine(waiter());
        cat.GetComponent<Animator>().Rebind();
        cat.GetComponent<Animator>().Update(0f);
        Menu.SetActive(false);
        ComicsChapters.SetActive(true);
    }
    public void toMenu()
    {
        StartCoroutine(waiter());
        Menu.SetActive(true);
        Gallery.SetActive(false);
    }
    public void toMenu2()
    {
        StartCoroutine(waiter());
        Menu.SetActive(true);
        ComicsChapters.SetActive(false);
    }
    public void Button_click()
    {
        click_audio.Play();
    }    
}
