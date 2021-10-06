using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NightmareController : MonoBehaviour
{
    private GameObject sleepingboy;
    public float movementTime = 5f;
    public float scaleValue = 0.5f;
    public float scaleChangeTime = 1f;

    [SerializeField] bool rotate = false;

    private float delta;

    void Start()
    {
        //飼い主の頭の位置を取得
        sleepingboy = GameObject.Find("HeadPosition");
        MoveToSleepingBoy();

        if(rotate == true)
        {
            transform.DOLocalRotate(new Vector3(0, 0, 360f), 3f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart).SetLink(gameObject);
        }

    }

    void Update()
    {
        delta += Time.deltaTime;

        //画面外に出たら消える
        if (gameObject.transform.position.y < -6f
            || 6f < gameObject.transform.position.y
            || gameObject.transform.position.x < -10f
            || 10f < gameObject.transform.position.x)
        {
            Destroy(gameObject);
        }
    }

    // プレイヤーに向かって拡大しながら移動
    void MoveToSleepingBoy()
    {
        //飼い主の位置取得
        float x = sleepingboy.transform.position.x;
        float y = sleepingboy.transform.position.y;

        //拡大縮小の繰り返し
        transform.DOScale(new Vector3(scaleValue, scaleValue, scaleValue), scaleChangeTime).SetLoops(-1, LoopType.Yoyo).SetLink(gameObject);

        //飼い主に向かって移動
        transform.DOLocalMove(new Vector3(x, y, 0), movementTime).SetLink(gameObject);
    }


    //Playerおよび少年の頭と接触すると消える。
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Head")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bakubaku")
        {
            Destroy(gameObject);
        }

    }
}
