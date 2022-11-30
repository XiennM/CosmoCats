using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    IEnumerator waiter()
    {
        yield return new WaitForSeconds((float)0.2);
    }

    public void RestartScene()
    {
        StartCoroutine(waiter());
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        StartCoroutine(waiter());
        SceneManager.LoadScene(0);
    }
}
