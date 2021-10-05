using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaccubusPointerController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;

    [SerializeField] GameObject targetSaccubus;

    public void DecidePosition()
    {
        // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
        float y = Random.Range(rangeA.position.y, rangeB.position.y);
        // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        Vector3 saccubusPos = targetSaccubus.transform.position;

        //サキュバスの近くに生成された場合は、再度位置設定。
        if (-2 < x - saccubusPos.x && x - saccubusPos.x < 2)
        {
            DecidePosition();
            return;
        }

        this.transform.position = new Vector3(x, y, 0);
    }


    //サキュバスと接触したら場所を移動
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Saccubus")
        {
            DecidePosition();
        }
    }
}
