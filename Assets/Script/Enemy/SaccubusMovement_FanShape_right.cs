using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SaccubusMovement_FanShape_right : MonoBehaviour
{
    [SerializeField] float moveTime = 5f;
    [SerializeField] float x = -7.5f;
    [SerializeField] float y = 6f;
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
            Shot_1();
        }

    }

    public void FanMove()
    {
        transform.DOMoveX(x, moveTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuad).SetLink(gameObject).SetRelative(true);
        transform.DOMoveY(y, moveTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.OutQuad).SetLink(gameObject).SetRelative(true);
    }


    public void Shot_1()
    {
        GameObject nightmare = Instantiate(nightmarePrefab1) as GameObject;
        nightmare.transform.position = this.gameObject.transform.position;
        delta = 0f;
    }


}
