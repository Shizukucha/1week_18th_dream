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
    private Animator animator;

    GameObject gameManager;

    [SerializeField] float shakeTime = 1.5f;

    void Start()
    {
        target = GameObject.Find("Pointer");
        this.gameManager = GameObject.Find("GameManager");

        isTouch = false;
        canMove = true;

        animator = GetComponent<Animator>();
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
            if(gameObject.transform.position == target.transform.position)
            {
                isTouch = true;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
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

            if(isTouch == true)
            {
                animator.SetBool("Walking", false);
            }
            else if(isTouch == false)
            {
                animator.SetBool("Walking", true);
            }
        }
        else
        {
            animator.SetBool("Walking", false);
        }

    }


    // 触れたものの識別はタグで管理。
    // AddScoreの引数に加算されるポイントを入れる。
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Nightmare1")
        {
            GameManager.I.AddScore(10);
            GameManager.I.AddSP(1);
            JUN_SEManagerScript.instance.JUN_SettingPlaySE(2);
            animator.SetTrigger("Eat");
        }

        if (other.gameObject.tag == "Nightmare2")
        {
            GameManager.I.AddScore(40);
            GameManager.I.AddSP(1);
            JUN_SEManagerScript.instance.JUN_SettingPlaySE(2);
            animator.SetTrigger("Eat");
        }

        if(other.gameObject.tag == "Nightmare3")
        {
            GameManager.I.AddScore(10);
            GameManager.I.AddSP(10);
            JUN_SEManagerScript.instance.JUN_SettingPlaySE(2);
            animator.SetTrigger("Eat");
        }

        if (other.gameObject.tag == "Bat")
        {
            Damage();
            GameManager.I.DecreaseScore(10);
            GameManager.I.ResetSP();
            JUN_SEManagerScript.instance.JUN_SettingPlaySE(8);
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
