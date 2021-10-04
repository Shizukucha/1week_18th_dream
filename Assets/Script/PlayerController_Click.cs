using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Click : MonoBehaviour
{
    private Vector3 setTapPos;
    public float speed = 7f;

    void Update()
    {
        // 移動する
        Move();
    }

    // タップした位置に移動する
    private void Move()
    {
        // ボタンを押したとき
        if (Input.GetKeyDown(KeyCode.Space))
        {
            setTapPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        // ボタンを押しているとき
        if (Input.GetKey(KeyCode.Space))
        {
            setTapPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            setTapPos.z = 10;// カメラとプレイヤーの距離

            // Lerpで動かす
            transform.position = Vector3.Lerp(transform.position, setTapPos, speed * Time.deltaTime);
        }



        /*
        // ボタンを押したとき
        if (Input.GetMouseButtonDown(0))
        {
            setTapPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        // ボタンを押しているとき
        if (Input.GetMouseButton(0))
        {
            setTapPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            setTapPos.z = 10;// カメラとプレイヤーの距離

            // Lerpで動かす
            transform.position = Vector3.Lerp(transform.position, setTapPos, speed * Time.deltaTime);
        }
        */
    }
}
