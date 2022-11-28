using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Gallery;

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Collection()
    {
        Gallery.transform.position = new Vector3(720, 1480, 0);
        Menu.SetActive(false);
        Gallery.SetActive(true);
    }
    public void toMenu()
    {
        Menu.SetActive(true);
        Gallery.SetActive(false);
    }
}
