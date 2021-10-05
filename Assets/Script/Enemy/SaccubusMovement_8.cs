using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaccubusMovement_8 : MonoBehaviour
{
    private float angle;
    Vector3 startPos;

    [SerializeField] float speed = 0.5f;
    [SerializeField] float xRange = 1f;
    [SerializeField] float yRange = 3f;


    private void Start()
    {
        startPos = this.gameObject.transform.position;
    }

   

    void Update()
    {
        angle += Time.deltaTime * speed;

        transform.position = new Vector3(
            // X軸
            startPos.x + Mathf.Sin(angle * 2) * xRange,

            // Y軸
            startPos.y + Mathf.Sin(angle) * yRange,

            // Z軸
            startPos.z
        );
    }

}
