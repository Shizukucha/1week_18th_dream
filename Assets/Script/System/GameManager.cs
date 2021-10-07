using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject timerText;
    GameObject scoreText;
    GameObject SPText;
    public float time = 60.0f;
    public static int score = 10;
    public int SP { get; set; }
    public static GameManager I;

    private GameObject bakubaku;

    private void Awake()
    {
        if (I == null)
        {
            I = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.scoreText = GameObject.Find("Score");
        this.SPText = GameObject.Find("SP");

        time = 60f;
        score = 0;
        SP = 0;

        bakubaku = GameObject.Find("Bakubaku");
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<Text>().text = this.time.ToString("F0");
        this.scoreText.GetComponent<Text>().text = score.ToString();
        this.SPText.GetComponent<Text>().text = "SP : " + SP.ToString();

        if (time < 0)
        {
            time = 0;
        }

        if(10 < SP)
        {
            SP = 10;
        }
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

    public void AddSP(int point)
    {
        SP += point;
    }

    public void ResetSP()
    {
        SP = 0;
    }


}
