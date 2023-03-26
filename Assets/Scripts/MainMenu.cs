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
    public  AudioSource click_audio;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("CatSkin")) PlayerPrefs.SetInt("CatSkin", 0);
        if (!PlayerPrefs.HasKey("RocketSkin")) PlayerPrefs.SetInt("RocketSkin", 0);
        instance = this;
        if (PlayerPrefs.HasKey("SaveScore"))
            h_score = PlayerPrefs.GetInt("SaveScore");
        else h_score = 0;
    }


    private void Start()
    {
        if (Score_script.High_score > h_score)
        {
            h_score = Score_script.High_score;
            PlayerPrefs.SetInt("SaveScore", h_score);
        }
        instance.highScore.text = h_score.ToString();
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
        Menu.SetActive(false);
        Gallery.SetActive(true);
    }
    public void Comics()
    {
        StartCoroutine(waiter());
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
