using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Click : MonoBehaviour
{
    private Vector3 setTapPos;
    public float speed = 2.5f;

    GameObject gameManager;

    private void Start()
    {
        this.gameManager = GameObject.Find("GameManager");
    }


    void Update()
    {
        // 移動する
        Move();
    }

    // マウスポインタの位置に移動する
    private void Move()
    {
        // スペースを押したとき
        if (Input.GetKeyDown(KeyCode.Space))
        {
            setTapPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        // スペースを押しているとき
        if (Input.GetKey(KeyCode.Space))
        {
            setTapPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            setTapPos.z = 10;// カメラとプレイヤーの距離

            // Lerpで動かす
            transform.position = Vector3.Lerp(transform.position, setTapPos, speed * Time.deltaTime);
        }
    }

    // 触れたものの識別はタグで管理。
    // AddScoreの引数に加算されるポイントを入れる。
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            this.gameManager.GetComponent<GameManager>().AddScore(10);
        }


    }
}
