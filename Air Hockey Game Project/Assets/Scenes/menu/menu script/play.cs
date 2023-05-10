using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("game");
    }
    public void menu()
    {
        SceneManager.LoadScene("menu");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}   

