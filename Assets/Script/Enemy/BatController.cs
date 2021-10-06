using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BatController : MonoBehaviour
{
    private GameObject player;

    [SerializeField] float movementTime = 1f;
    [SerializeField] float deleteTime;

    private float delta;

    void Start()
    {
        //飼い主の頭の位置を取得
        player = GameObject.Find("PlayerCore");
        MoveToPlayer();
    }

    void Update()
    {
        delta += Time.deltaTime;

        //画面外に出たら消える
        if (gameObject.transform.position.y < -4.5f
            || 4.5f < gameObject.transform.position.y
            || gameObject.transform.position.x < -8.2f
            || 8.2f < gameObject.transform.position.x)
        {
            MoveToPlayer();
        }

        //一定時間で消える。
        if(deleteTime < delta)
        {
            Destroy(gameObject);
        }
    }

    // プレイヤーに向かって拡大しながら移動
    void MoveToPlayer()
    {
        //飼い主の位置取得
        float x = player.transform.position.x;
        float y = player.transform.position.y;

        //プレイヤーに向かって移動
        transform.DOLocalMove(new Vector3(x, y, 0), movementTime).SetLink(gameObject).OnComplete(MoveToPlayer);

        //飼い主の方向に向く
        /*
        float angle = GetAngle(this.gameObject.transform.position, player.transform.position);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        */


        //進行方向によって向きを変える。
        //TODO:実際の画像を入れた時に調整。
        /*
        if(90 < angle && angle <= 270)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        */
    }


    //Playerおよび少年の頭と接触すると消える。
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.DOScale(new Vector3(2f, 2f, 2f), 0.4f).SetLink(gameObject).OnComplete(Vanish);
        }
    }

    float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 dt = target - start;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }

    public void Vanish()
    {
        Destroy(gameObject);
    }
}
