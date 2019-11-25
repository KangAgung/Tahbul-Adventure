using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameStatus.lives = 3;
        GameStatus.score = 0;
        GameStatus.score_temp = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void openPlaylvl1()
    {
        SceneManager.LoadScene(1);
    }
    public void openPlaylvl2()
    {
        SceneManager.LoadScene(2);
    }
    public void openPlaylvl3()
    {
        SceneManager.LoadScene(1);
    }
    public void openPlaylvl4()
    {
        SceneManager.LoadScene(1);
    }
    public void openPlaylvl5()
    {
        SceneManager.LoadScene(1);
    }
    public void openPlaylvl6()
    {
        SceneManager.LoadScene(1);
    }
    public void openPlaylvl7()
    {
        SceneManager.LoadScene(1);
    }
    public void openPlaylvl8()
    {
        SceneManager.LoadScene(1);
    }
    public void openPlaylvl9()
    {
        SceneManager.LoadScene(1);
    }
    public void openPlaylvl10()
    {
        SceneManager.LoadScene(1);
    }
    public void gameExit()
    {
        Application.Quit();
    }
}