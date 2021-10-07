using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BakubakuController : MonoBehaviour
{
    [SerializeField] float moveTime;

    private Vector3 startPos;
    private int sp;
    private int maxSP;
    private bool canMove;


    private void Start()
    {
        startPos = gameObject.transform.position;
        canMove = true;
        maxSP = GameManager.I.MaxSP;
    }

    // Update is called once per frame
    void Update()
    {
        sp = GameManager.I.SP;


        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.Return))
        {
            if (maxSP <= sp && canMove == true)
            {
                Move();
                GameManager.I.ResetSP();
                GameManager.I.AddMaxSP();
                JUN_SEManagerScript.instance.JUN_SettingPlaySE(7);

            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Nightmare1")
        {
            GameManager.I.AddScore(10);
            JUN_SEManagerScript.instance.JUN_SettingPlaySE(2);
        }

        if (other.gameObject.tag == "Nightmare2")
        {
            GameManager.I.AddScore(30);
            JUN_SEManagerScript.instance.JUN_SettingPlaySE(2);
        }
    }

    void Move()
    {
        canMove = false;
        transform.DOMoveX(-30, moveTime).SetEase(Ease.Linear).SetLink(gameObject).SetRelative(true).OnComplete(BackState);
    }

    public void BackState()
    {
        gameObject.transform.position = startPos;
        canMove = true;
    }

}
