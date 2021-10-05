using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaccubusMovement_random : MonoBehaviour
{
    GameObject SaccubusPointerGenerator;

    public GameObject target;
    [SerializeField] float speed;
    [SerializeField] float waitTime;

    private bool wait = true;

    void Start()
    {
        target = GameObject.Find("SaccubusPointer");
        this.SaccubusPointerGenerator = GameObject.Find("SaccubusPointerGenerator");

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

            Invoke("StartMove", waitTime);
        }
    }

    public void StartMove()
    {
        wait = false;
    }

}
