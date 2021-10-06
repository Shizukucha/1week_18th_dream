using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySaccubus : MonoBehaviour
{
    // ボスの生成
    //８方向に玉を打つ　→　360°を8分割して打つ
    //好きな角度に玉を打つ
    // 一定間隔で実行する
    // ・コルーチン:時間の制御がめっちゃ楽になる



    public EnemyBullet bulletPrefab;
    GameObject sleeper;



    void Start()
    {
        sleeper = GameObject.FindWithTag("SleepingBoy");
        StartCoroutine(CPU());//四回８方向に打つのを繰り返しなさい

        /*
        Shot(-Mathf.PI / 4f); // 右斜下
        Shot(-Mathf.PI / 2f); // 真下
        Shot(-Mathf.PI*3 / 4f); //左斜下3/4PI　135°
        */
    }

    // Update is called once per frame
    void Shot(float angle, float speed)
    {
        EnemyBullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.BulletSetting(angle, speed); // PI/4fは45°
    }

    IEnumerator CPU()
    {
        // 特定の位置まで移動
        /*
        while (transform.position.y >1f)
        {
                transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
                yield return null; // 1フレーム待つ

        }
        */
        while (true)
        {
            yield return ShotX(16,1);
            yield return new WaitForSeconds(1f);
            yield return WaveNShotMCurve(2, 16);　// 6方向(y)に二個ずつ打つのを3回繰り返す(x)
            yield return new WaitForSeconds(1f);
            yield return WaveNShotM(3, 16);
            yield return new WaitForSeconds(1f);
            yield return WaveNPlayerAimShot(4, 6);
            yield return new WaitForSeconds(1f);

            //yield return new WaitForSeconds(1f);

        }
    }



    void ShotN(int count, float speed)
    {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount); // 2PI:360 
            Shot(angle, speed);
        }
    }
    IEnumerator ShotX(int count, float speed)
    {
        Debug.Log("周囲から同心円状にX個分球を出す");
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount); // 2PI:360 
            Shot(angle, speed);
        }
        JUN_SEManagerScript.instance.JUN_SettingPlaySE(10);//サキュバスの攻撃音
        yield return new WaitForSeconds(0.1f);
    }

    // Playerを狙う
    //　Playerの位置を取得して
    //　どの角度に打てばいいか計算

    void PlayerAimShot(int count, float speed)
    {
        //この弾幕前にplayerが倒されていたら何もしない
        if (sleeper != null)
        {
            //　自分からみたPlayerの位置を計算する
            Vector3 diffPosition = sleeper.transform.position - transform.position;
            //  自分から見たPlayerの角度を出す:傾きから角度を出す:アークタンジェントを使う
            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);


            int bulletCount = count;
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = (i - bulletCount / 2f) * ((Mathf.PI / 3f) / bulletCount); // PI/2f（90°）を発射する玉の数で割ってそれが何個分に成るか 。(i - bulletCount/2f )がなければ中心の弾ではなく一発目がプレイヤーめがけて飛んでしまうので個数をずらして調整。
                Shot(angleP + angle, speed);// 
            }

        }

    }


    IEnumerator WaveNShotM(int n, int m) 
    {
        Debug.Log("周囲から同心円状にN個分球を出す×M回");
        for (int w = 0; w < 4; w++)
        {
            ShotN(m, 2);
            yield return new WaitForSeconds(0.3f);//
        }
        JUN_SEManagerScript.instance.JUN_SettingPlaySE(10);//サキュバスの攻撃音
    }
    IEnumerator ShotNCurve(int count, float speed)
    {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount); // 2PI:360 
            Shot(angle - Mathf.PI/2f, speed);// - Mathf.PI/2fで９０度回転
            Shot(-angle - Mathf.PI / 2f, speed);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator WaveNShotMCurve(int n, int m)
    {
        Debug.Log("ハート形っぽい球");
        for (int w = 0; w < n; w++)
        {
            yield return ShotNCurve(m, 2);
            yield return new WaitForSeconds(0.3f);//徐々にずらしながら打つ　一度にすると弾が全て重なってしまう
        }
        JUN_SEManagerScript.instance.JUN_SettingPlaySE(10);//サキュバスの攻撃音

    }
    /*IEnumerator WaveNPlayerAimShot(int n, int m)
    {
        for (int w = 0; w < n; w++)
        {
            yield return new WaitForSeconds(1f);
            PlayerAimShot(m, 3);
        }

    }*/

    IEnumerator WaveNPlayerAimShot(int n, int m)
    {
        Debug.Log("プレイヤーの追尾弾");
        for (int w = 0; w < n; w++)
        {
            yield return new WaitForSeconds(1f);
            PlayerAimShot(m, 3);
        }
        JUN_SEManagerScript.instance.JUN_SettingPlaySE(10);//サキュバスの攻撃音

    }

}
