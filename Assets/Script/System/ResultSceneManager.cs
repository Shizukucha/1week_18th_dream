using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using naichilab;

public class ResultSceneManager : MonoBehaviour
{
    [SerializeField] GameObject score;
    private int scoreResult;


    // Start is called before the first frame update
    void Start()
    {
        scoreResult = GameManager.GetScore();

        Text scoreText = score.GetComponent<Text>();

        scoreText.text = scoreResult.ToString();

        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(scoreResult);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
