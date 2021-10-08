using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject timerText;
    GameObject scoreText;
    public float time = 92.0f;
    public static int score = 10;
    public int SP = 0;
    public int MaxSP = 10;
    public static GameManager I;

    private bool oneShot = false;

    [SerializeField] int additionalPointToMaxSP = 3;

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

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;

        if (time < 0)
        {
            time = 0;

            if(oneShot == false)
            {
                //タイムアップ音
                JUN_SEManagerScript.instance.JUN_SettingPlaySE(5);
                oneShot = true;
            }

            StartCoroutine("DelaySceneTransition");
        }

        if (MaxSP < SP)
        {
            SP = MaxSP;
        }

        if(score < 0)
        {
            score = 0;
        }

        this.timerText.GetComponent<Text>().text = this.time.ToString("F0");
        this.scoreText.GetComponent<Text>().text = score.ToString();
    }

    IEnumerator DelaySceneTransition()
    {
        yield return new WaitForSeconds(2);
        SceneSwitcher.instance.JUN_SceneTransion();// 2秒待つ
    }


    //スコア加算。プレイヤーから呼び出し。
    public void AddScore(int point)
    {
        if(0 < time)
        {
            score += point;
        }
    }

    public static int GetScore()
    {
        return score;
    }

    public void AddSP(int point)
    {
        if(0 < time)
        {
            SP += point;
        }
    }

    public void ResetSP()
    {
        SP = 0;
    }

    public void AddMaxSP()
    {
        MaxSP += additionalPointToMaxSP;
    }


}
