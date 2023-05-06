using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;

    // Start is called before the first frame update
    IEnumerator waiter()
    {
        yield return new WaitForSeconds((float)0.2);
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        StartCoroutine(waiter());
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        StartCoroutine(waiter());
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
