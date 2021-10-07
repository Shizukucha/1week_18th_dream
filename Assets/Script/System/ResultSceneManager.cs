using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using naichilab;

public class ResultSceneManager : MonoBehaviour
{
    [SerializeField] GameObject score;
    private int scoreResult;

    [SerializeField] GameObject awesome;
    [SerializeField] GameObject good;
    [SerializeField] GameObject soso;

    [SerializeField] int awesomeScore = 600;
    [SerializeField] int goodScore = 400;


    // Start is called before the first frame update
    void Start()
    {
        scoreResult = GameManager.GetScore();

        Text scoreText = score.GetComponent<Text>();

        scoreText.text = scoreResult.ToString();

        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(scoreResult);

        //スコアに応じてパネルを切り替え
        if(scoreResult < goodScore)
        {
            soso.SetActive(true);
            JUN_SEManagerScript.instance.JUN_SettingPlaySE(10);
        }
        else if (goodScore <= scoreResult && scoreResult < awesomeScore)
        {
            good.SetActive(true);
            JUN_SEManagerScript.instance.JUN_SettingPlaySE(10);
        }
        else if (awesomeScore <= scoreResult)
        {
            awesome.SetActive(true);
            JUN_SEManagerScript.instance.JUN_SettingPlaySE(10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
