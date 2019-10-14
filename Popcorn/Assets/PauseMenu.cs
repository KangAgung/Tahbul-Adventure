using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    private bool CekPause;
    public GameObject pauseMenu;
    public int noScene;
    public GameObject GameOverMenu;
    // Start is called before the first frame update
    void Start()
    {
        CekPause = false;
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        if (GameStatus.lives == 0)
        {
            GameOverMenu.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (GameStatus.lives == 0)
        {
            GameOverMenu.SetActive(true);
        }
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Rertry()
    {
        GameStatus.lives = GameStatus.lives - 1;
        SceneManager.LoadScene(noScene);
    }

    public void Pause()
    {
        if (!CekPause)
        {
            Time.timeScale = 0.0f;
            CekPause = true;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            CekPause = false;
            pauseMenu.SetActive(false);
        }
    }
}
