using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public string tutorial;
    public void LoadGame()
    {
        SceneManager.LoadScene(tutorial);
        SaveManager.Instance.LoadGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(tutorial);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
