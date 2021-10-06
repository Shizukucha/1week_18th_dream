using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
   // [SerializeField] float bulletSpeed;
    [SerializeField] float bulletSize;
    [SerializeField] float bulletSpeed;

    float dx; // X方向
    float dy; // Y方向

    

    // 上に動く
    private void Update()
    {

        
        transform.localScale = new Vector3(bulletSize, bulletSize, 0);

        transform.position += new Vector3(dx, dy, 0) * Time.deltaTime ;
        //一定の範囲を超えると破壊。
        /*
        if(transform.position.y > 3)
        {
            Destroy(gameObject);
        }
       */
    }

    public void BulletSetting(float angle, float speed )
    {
        dx = Mathf.Cos(angle) * bulletSpeed;
        dy = Mathf.Sin(angle) * bulletSpeed;
    }

    //Playerおよび寝ている少年と接触すると消えるようにしました。
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "SleepingBoy")
        {
            Destroy(gameObject);
        }

    }

}
