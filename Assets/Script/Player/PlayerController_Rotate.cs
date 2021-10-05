using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Rotate : MonoBehaviour
{
    public float speed = 2.0f;
    public float direction = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.gameObject.transform.position;

        pos.x = Mathf.Sin(Time.time * speed * direction) * 4f;
        pos.y = Mathf.Cos(Time.time * speed) * 2f;

        //方向反転
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = -1 * direction;
        }

        this.gameObject.transform.position = pos;

    }
}
