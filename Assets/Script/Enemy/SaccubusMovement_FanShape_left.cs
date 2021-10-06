using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SaccubusMovement_FanShape_left : MonoBehaviour
{
    private float angle;
    Vector3 startPos;

    [SerializeField] float moveTime = 3.5f;
    [SerializeField] float x = -6.5f;
    [SerializeField] float y = -4.5f;
    public float span = 6.0f;

    [SerializeField] GameObject nightmarePrefab1;

    private float delta = 0;


    private void Start()
    {
        FanMove();
    }



    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            // サキュバスの攻撃音の仮追加（音自体は変わる可能性あり）Byじゅーん
            JUN_SEManagerScript.instance.JUN_SettingPlaySE(10);
            Shot_1();
        }

    }

    public void FanMove()
    {
        transform.DOMoveX(x, moveTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.OutQuad).SetLink(gameObject).SetRelative(true); ;
        transform.DOMoveY(y, moveTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuad).SetLink(gameObject).SetRelative(true); ;
    }


    public void Shot_1()
    {
        GameObject nightmare = Instantiate(nightmarePrefab1) as GameObject;
        nightmare.transform.position = this.gameObject.transform.position;
        delta = 0f;
    }

}
