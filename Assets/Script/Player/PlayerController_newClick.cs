using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_newClick : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public bool isTouch;

    GameObject gameManager;


    void Start()
    {
        target = GameObject.Find("Pointer");
        this.gameManager = GameObject.Find("GameManager");

        isTouch = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Pointer")
        {
            isTouch = true;
        }
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            isTouch = true;
        }

        if(Input.GetMouseButtonDown(0))
        {
            isTouch = false;
        }

        if (isTouch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
    }


    // 触れたものの識別はタグで管理。
    // AddScoreの引数に加算されるポイントを入れる。
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            this.gameManager.GetComponent<GameManager>().AddScore(10);
        }
    }
}
