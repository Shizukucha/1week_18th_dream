using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SaccubusMovement_FanShape_right : MonoBehaviour
{
    [SerializeField] float moveTime = 5f;
    [SerializeField] float x = -7.5f;
    [SerializeField] float y = 6f;
    [SerializeField] float span = 6.0f;
    [SerializeField] float changedSpan = 3.0f;
    [SerializeField] float spanChangeTime = 40;

    [SerializeField] GameObject nightmarePrefab1;
    [SerializeField] GameObject nightmarePrefab2;
    [SerializeField] GameObject nightmarePrefab3;
    [SerializeField] GameObject batPrefab;

    private float delta = 0;
    private float time;
    private GameObject nightmare;
    private Animator animator;

    private void Start()
    {
        FanMove();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        time = GameManager.I.time;

        //??????????????
        if (time < spanChangeTime)
        {
            span = changedSpan;
        }

        this.delta += Time.deltaTime;
        if (this.span < this.delta)
        {
            /*
            // ?T?L???o?X???U?????????????i?????????????????\???????jBy?????[??
            JUN_SEManagerScript.instance.JUN_SettingPlaySE(10);
            */

            Shot();
        }
    }

    public void FanMove()
    {
        transform.DOMoveX(x, moveTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuad).SetLink(gameObject).SetRelative(true);
        transform.DOMoveY(y, moveTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.OutQuad).SetLink(gameObject).SetRelative(true);
    }


    public void Shot()
    {

        int generateDice;
        generateDice = Random.Range(1, 11);

        animator.SetTrigger("AttackL");


        if (60 < time) // ①:70%,②:30%
        {
            if (generateDice < 8)
            {
                GenerateNightmare_1();
            }
            else if (8 <= generateDice && generateDice < 11)
            {
                GenerateNightmare_2();
            }
        }
        else if (time <= 60)// ①:50%,②:10%,③10%,④:30%
        {
            if (generateDice < 6)
            {
                GenerateNightmare_1();
            }
            else if (6 <= generateDice && generateDice < 8)
            {
                GenerateNightmare_2();
            }
            else if (8 <= generateDice && generateDice < 9)
            {
                GenerateNightmare_3();
            }
            else if (9 <= generateDice && generateDice < 11)
            {
                GenerateBat();
            }
        }

        nightmare.transform.position = this.gameObject.transform.position;
        delta = 0;
    }

    public void GenerateNightmare_1()
    {
        nightmare = Instantiate(nightmarePrefab1) as GameObject;
    }

    public void GenerateNightmare_2()
    {
        nightmare = Instantiate(nightmarePrefab2) as GameObject;
    }

    public void GenerateNightmare_3()
    {
        nightmare = Instantiate(nightmarePrefab3) as GameObject;
    }

    public void GenerateBat()
    {
        nightmare = Instantiate(batPrefab) as GameObject;
    }
}

