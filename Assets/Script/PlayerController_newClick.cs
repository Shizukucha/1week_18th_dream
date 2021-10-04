using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_newClick : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public bool isTouch;

    void Start()
    {
        target = GameObject.Find("Pointer");
        bool isTouch = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Pointer")
        {
            bool isTouch = true;
        }
    }

    void Update()
    {
        if (isTouch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
    }
}
