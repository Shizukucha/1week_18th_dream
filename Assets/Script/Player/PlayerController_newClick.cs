using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController_newClick : MonoBehaviour
{
    private GameObject target;
    public float speed;
    private bool isTouch;
    private bool canMove;

    GameObject gameManager;

    [SerializeField] float shakeTime = 1.5f;


    void Start()
    {
        target = GameObject.Find("Pointer");
        this.gameManager = GameObject.Find("GameManager");

        isTouch = false;
        canMove = true;
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
        if(canMove == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                isTouch = true;
            }

            if (Input.GetMouseButtonDown(0))
            {
                isTouch = false;
            }

            if (isTouch == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
            }
        }
    }


    // 触れたものの識別はタグで管理。
    // AddScoreの引数に加算されるポイントを入れる。
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Nightmare1")
        {
            this.gameManager.GetComponent<GameManager>().AddScore(10);
        }

        if (other.gameObject.tag == "Nightmare2")
        {
            this.gameManager.GetComponent<GameManager>().AddScore(30);
        }

        if (other.gameObject.tag == "Bat")
        {
            Damage();
        }
    }

    public void Damage()
    {
        canMove = false;
        transform.DOShakePosition(shakeTime, 0.2f).OnComplete(SetCanMoveTrue);
    }

    public void SetCanMoveTrue()
    {
        canMove = true;
    }



}
