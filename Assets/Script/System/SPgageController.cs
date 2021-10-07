using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPgageController : MonoBehaviour
{
    Slider spSlider;
    private int SP;
    private int maxSP;

    [SerializeField] GameObject charged;

    // Use this for initialization
    void Start()
    {

        spSlider = GetComponent<Slider>();
        maxSP = GameManager.I.MaxSP;


        //スライダーの最大値の設定
        spSlider.maxValue = maxSP;
    }

    // Update is called once per frame
    void Update()
    {
        //スライダーの最大値の設定
        maxSP = GameManager.I.MaxSP;
        spSlider.maxValue = maxSP;


        //スライダーの現在値の設定
        SP = GameManager.I.SP;
        spSlider.value = SP;

        if(maxSP <= SP)
        {
            charged.SetActive(true);
        }
        else
        {
            charged.SetActive(false);
        }
    }
}
