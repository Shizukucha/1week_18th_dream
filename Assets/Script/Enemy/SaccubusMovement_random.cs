using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaccubusMovement_random : MonoBehaviour
{
    public GameObject target;
    [SerializeField] float speed;
    [SerializeField] float shotTime = 0.5f;
    [SerializeField] float waitTime = 1.0f;

    [SerializeField] GameObject nightmarePrefab;

    private bool wait = true;

    void Start()
    {
        target = GameObject.Find("SaccubusPointer");
        wait = false;
    }

    
    // Update is called once per frame
    void Update()
    {
        if(wait == false)
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
        GameObject nightmare = Instantiate(nightmarePrefab) as GameObject;
        nightmare.transform.position = this.gameObject.transform.position;
    }


}
