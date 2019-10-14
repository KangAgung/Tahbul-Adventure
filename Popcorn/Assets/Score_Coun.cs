using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score_Coun : MonoBehaviour
{
    public int score = 0;
    public Text scoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        scoreLabel.text = GameStatus.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //if(other.gameObject.tag == "Player")
        //{
            Destroy(gameObject);
            GameStatus.score_temp += score;
            GameStatus.score_temp += GameStatus.score;
            scoreLabel.text = GameStatus.score_temp.ToString();
        //}
    }
}
