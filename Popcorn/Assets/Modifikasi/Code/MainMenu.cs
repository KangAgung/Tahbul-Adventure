﻿using System.Collections;
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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameMulai()
    {
        SceneManager.LoadScene(1);
    }

    public void gameExit()
    {
        Application.Quit();
    }
}