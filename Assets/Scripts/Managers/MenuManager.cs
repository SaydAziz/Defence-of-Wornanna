using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject tutMenu;

    public void StartGame()
    {
        SceneManager.LoadScene("TestScene");
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToggleTut()
    {
        tutMenu.SetActive(true);

    }

    public void Back()
    {
        tutMenu.SetActive(false);
    }
}
