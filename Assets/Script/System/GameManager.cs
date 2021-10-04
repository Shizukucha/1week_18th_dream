using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject timerText;
    GameObject scoreText;
    public float time = 60.0f;
    public static int score = 999;

    // Start is called before the first frame update
    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.scoreText = GameObject.Find("Score");

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<Text>().text = this.time.ToString("F0");
        this.scoreText.GetComponent<Text>().text = "Score : " + score.ToString();
    }

    //スコア加算。プレイヤーから呼び出し。
    public void AddScore(int point)
    {
        score += point;
    }

    public static int GetScore()
    {
        return score;
    }



}
