using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;

    public Text score_counter;

    public GameObject player;

    // Start is called before the first frame update
    IEnumerator waiter()
    {
        yield return new WaitForSeconds((float)0.2);
    }

    public void RestartScene()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            if (int.Parse(score_counter.text) > PlayerPrefs.GetInt("SaveScore"))
                PlayerPrefs.SetInt("SaveScore", int.Parse(score_counter.text));
        }
        Time.timeScale = 1f;
        StartCoroutine(waiter());
        SceneManager.LoadScene(1);
        player.GetComponent<Move>().isPaused = false;
    }
    public void Menu()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            if (int.Parse(score_counter.text) > PlayerPrefs.GetInt("SaveScore"))
                PlayerPrefs.SetInt("SaveScore", int.Parse(score_counter.text));
        }
        Time.timeScale = 1f;
        player.GetComponent<Move>().isPaused = false;
        StartCoroutine(waiter());
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        player.GetComponent<Move>().isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        player.GetComponent<Move>().isPaused = false;
        player.GetComponent<Move>().isResumed = true;
        pauseMenu.SetActive(false);
    }
}
