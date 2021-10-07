using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaccubusMovement_random : MonoBehaviour
{
    public GameObject target;
    [SerializeField] float speed = 0.0275f;
    [SerializeField] float changedSpeed = 0.04f;
    [SerializeField] float speedChangeTime = 20f;
    [SerializeField] float shotTime = 0.5f;
    [SerializeField] float waitTime = 1.0f;

    [SerializeField] GameObject nightmarePrefab1;
    [SerializeField] GameObject nightmarePrefab2;
    [SerializeField] GameObject batPrefab;

    private bool wait = true;
    private Animator animator;

    private float time;
    private GameObject nightmare;

    void Start()
    {
        target = GameObject.Find("SaccubusPointer");
        wait = false;

        animator = GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {
        time = GameManager.I.time;

        //一定時間、後放出頻度が変わる
        if (time < speedChangeTime)
        {
            speed = changedSpeed;
        }

        if (wait == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
    }
    

    // 触れたものの識別はタグで管理。
    // AddScoreの引数に加算されるポイントを入れる。
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SaccubusPointer")
        {
            //ポインターの取得
            target = GameObject.Find("SaccubusPointer");

            wait = true;

            /*
            // サキュバスの攻撃音の仮追加（音自体は変わる可能性あり）Byじゅーん
            JUN_SEManagerScript.instance.JUN_SettingPlaySE(10);
            */

            Invoke("Shot", shotTime);
            
            Invoke("StartMove", waitTime);
        }
    }

    public void StartMove()
    {
        wait = false;
    }

    public void Shot()
    {
        int generateDice;
        generateDice = Random.Range(0, 11);

        animator.SetTrigger("Attack");


        if (20 < time) // 40秒までは、①:90%、②:10%
        {
            if (generateDice < 10)
            {
                GenerateNightmare_1();
            }
            else if (10 <= generateDice && generateDice < 11)
            {
                GenerateNightmare_2();
            }
        }
        else if (time <= 20)// 40秒をすぎれば、①:30%、②:20%、③:50%
        {
            if (generateDice < 4)
            {
                GenerateNightmare_1();
            }
            else if (4 <= generateDice && generateDice < 6)
            {
                GenerateNightmare_2();
            }
            else if (6 <= generateDice && generateDice < 11)
            {
                GenerateBat();
            }
        }

        nightmare.transform.position = this.gameObject.transform.position;
    }

    public void GenerateNightmare_1()
    {
        nightmare = Instantiate(nightmarePrefab1) as GameObject;
    }

    public void GenerateNightmare_2()
    {
        nightmare = Instantiate(nightmarePrefab2) as GameObject;
    }

    public void GenerateBat()
    {
        nightmare = Instantiate(batPrefab) as GameObject;
    }


}
