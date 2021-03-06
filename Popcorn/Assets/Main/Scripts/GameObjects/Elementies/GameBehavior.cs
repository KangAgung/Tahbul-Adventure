﻿using UnityEngine;
using Popcorn.Bases;
using UnityEngine.UI;
using Popcorn.Managers;
using System.Collections;
using Popcorn.ObjectsServices;
using Popcorn.GameObjects.Objects;
using Times = Popcorn.Metadatas.Times;
using Errors = Popcorn.Metadatas.Strings.Errors;
using ObjectsTags = Popcorn.Metadatas.Tags.Objects;
using PersonsTags = Popcorn.Metadatas.Tags.Persons;
using ElementiesTags = Popcorn.Metadatas.Tags.Elementies;
using UIElementiesTags = Popcorn.Metadatas.Tags.UIElementies;
using UnityEngine.SceneManagement;

namespace Popcorn.GameObjects.Elementies
{

    [RequireComponent(typeof(CameraBehavior))]
    [RequireComponent(typeof(AudioSource))]
    public class GameBehavior : MonoBehaviour
    {
        public int nextScene;
        public int noScene;
        public GameObject live1;
        public GameObject live2;
        public GameObject live3;
        public enum GameStates { Paused, Runing, TimeOut, Ended, NextLvl };

        [SerializeField] Times.ScenesTimes scenesTime = Times.ScenesTimes.Normal;
        [SerializeField] Text timeScreen;

        PlayerBase player;
        EndPoint endPoint;

        float time;
        float alertTime = 30;
        bool inAlertTime = false;

        AudioSource timeOutAudioSource;
        AudioSource backgroundMusic;

        [HideInInspector]
        public static GameStates GameState { get; protected set; }

        void Awake()
        {
            GetPlayer();
            GetAndCheckElements();
            GetAudioSources();

            time = (float)scenesTime;
            GameState = GameStates.Paused;
        }

        void GetAudioSources()
        {
            timeOutAudioSource = (AudioSource)Getter.ComponentInChild(this, gameObject, typeof(AudioSource), 0);
            backgroundMusic = (AudioSource)Getter.ComponentInChild(this, gameObject, typeof(AudioSource), 1);
        }

        void GetAndCheckElements()
        {
            GameObject endPointObject = Getter.SingleInstanceObjectWithTag(caller: this,
                tag: ObjectsTags.EndPoint.ToString(),
                errorOnNotFound: Errors.EndpointNotFound,
                multiplesInstance: Errors.MultipleEndpointsFound);

            endPoint = (EndPoint)Getter.Component(this, endPointObject, typeof(EndPoint));

            Checker.SingleExistence(tag: ObjectsTags.StartPoint.ToString(),
                errorIfNone: Errors.StartPointNotFound,
                errorIfMultiple: Errors.MultipleStartPointsFound);

            Checker.CruzedHorizontalPosition(leftGameObject: GameObject.FindGameObjectWithTag(ObjectsTags.StartPoint.ToString()),
                rightGameObject: endPointObject,
                error: Errors.StartAndEndpointCruzed);

            Checker.SingleOrNoneExistence(tag: ElementiesTags.Destructor.ToString(),
                errorIfMultiple: Errors.MultipleDestructorsFound);

            Checker.SingleExistence(tag: UIElementiesTags.Time.ToString(),
                 errorIfNone: Errors.TimeNotFound,
                 errorIfMultiple: Errors.MultipleTimesFound);

            Checker.SingleExistence(tag: ElementiesTags.Camera.ToString(),
                 errorIfNone: Errors.CameraNotFound,
                 errorIfMultiple: Errors.MultipleCamerasFound);

            if (timeScreen == null) { throw new UnityException(Errors.TimeNotSetInGameBehavior); }
        }

        void GetPlayer()
        {
            GameObject playerObject = Getter.SingleInstanceObjectWithTag(caller: this,
                tag: PersonsTags.Player.ToString(),
                errorOnNotFound: Errors.PlayerNotFound,
                multiplesInstance: Errors.MultiplePlayersFound);

            player = (PlayerBase)Getter.Component(this, playerObject, typeof(PlayerBase));
        }

        void Start()
        {
            AudioManager.Instance.PlayBackgroundMusic(caller: this, music: backgroundMusic);
            GameState = GameStates.Runing;
            //------------------------------------
            if (GameStatus.lives == 2)
            {
                live3.SetActive(false);
            }
            else if (GameStatus.lives == 1)
            {
                live3.SetActive(false);
                live2.SetActive(false);
            }
            else if (GameStatus.lives == 0)
            {
                SceneManager.LoadScene(4);
            }
            //GameStatus.score_temp = 0;
        }

        void Update()
        {

            switch (GameState)
            {
                case GameStates.Runing:

                    if (!IsGameFinished())
                    {
                        CountingTime();
                        SetTimeInScreen();
                        CheckTime();
                    }
                    break;
                    //---------------------------------------------
                case GameStates.Ended:
                    AudioManager.Instance.StopBackgroundMusic(caller: this);
                    GameIsOver();
                    break;

                case GameStates.NextLvl:
                    AudioManager.Instance.StopBackgroundMusic(caller: this);
                    GameState = GameStates.Paused;
                    StartCoroutine(CallNextScene2());
                    break;

                case GameStates.TimeOut:
                    GameState = GameStates.Ended;
                    break;
            }
        }

        void CountingTime() { time -= UnityEngine.Time.deltaTime; }

        void CheckTime()
        {
            if (time < 1) { GameState = GameStates.TimeOut; }
            else if (time <= alertTime && !inAlertTime) { StartAlertTime(); }
        }

        void StartAlertTime()
        {
            inAlertTime = true;
            timeScreen.color = Color.red;
            AudioManager.Instance.PlaySoundOnce(caller: this, sound: timeOutAudioSource);
        }

        void SetTimeInScreen() { timeScreen.text = ((int)time).ToString(); }

        //------------------------------------------------------------------
        bool IsGameFinished()
        {
            if (endPoint.WasReachedTheEnd)
            {
                GameState = GameStates.NextLvl;
                return true;
            }
            if(!player.IsAlive)
            {
                GameState = GameStates.Ended;
                return true;
            }
            return false;
        }

        void GameIsOver()
        {
            if (GameState == GameStates.Ended)
            {
                GameState = GameStates.Paused;
                StartCoroutine(CallNextScene());
            }
        }

        IEnumerator CallNextScene()
        {
            yield return new WaitForSeconds(Times.Waits.Medium);
            SceneManager.LoadScene(noScene);
            GameStatus.lives -= 1;
            GameStatus.score_temp = GameStatus.score;
            //ScenesManager.Instance.CallNextScene();
        }
        IEnumerator CallNextScene2()
        {
            yield return new WaitForSeconds(Times.Waits.Medium);
            SceneManager.LoadScene(nextScene);
            GameStatus.score_temp += (int)time * 50;
            GameStatus.score = GameStatus.score_temp;
            //GameStatus.score_temp = 0;
        }
    }

}