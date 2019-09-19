using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    private bool CekPause;
    public GameObject pauseMenu;
    

    // Start is called before the first frame update
    void Start()
    {
        CekPause = false;
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
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
