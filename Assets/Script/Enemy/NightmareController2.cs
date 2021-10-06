using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NightmareController2 : MonoBehaviour
{
    private GameObject sleepingboy;
    [SerializeField] float scaleValue = 0.5f;
    [SerializeField] float scaleChangeTime = 1f;
    [SerializeField] float delayTime = 3f;
    [SerializeField] float movementTime = 5f;




    private float delta;

    void Start()
    {
        //飼い主の頭の位置を取得
        sleepingboy = GameObject.Find("HeadPosition");

        //飼い主の頭に向かって飛ぶ
        MoveToSleepingBoy();

        //スケールの変更
        transform.DOScale(new Vector3(scaleValue, scaleValue, scaleValue), scaleChangeTime).SetLink(gameObject);

        //飼い主の方向に向く
        float angle = GetAngle(this.gameObject.transform.position, sleepingboy.transform.position);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);

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

        //飼い主に向かって移動（delayTime秒遅延）
        transform.DOLocalMove(new Vector3(x, y, 0), movementTime).SetLink(gameObject).SetDelay(delayTime); ;
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

    float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 dt = target - start;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }


}
