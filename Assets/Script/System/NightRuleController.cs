using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightRuleController : MonoBehaviour
{
    private float maxValue;
    private float timeValue;

    [SerializeField] float firstAlpha = 100;

    // Start is called before the first frame update
    void Start()
    {
        byte i = (byte)firstAlpha;

        GetComponent<Image>().color = new Color32(14, 40, 138, i);

        maxValue = GameManager.I.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeValue = GameManager.I.time;

        if(0 <= timeValue)
        {


            float alpha_f = firstAlpha * timeValue / maxValue;

            byte alpha = (byte)alpha_f;

            Debug.Log(alpha);
            UpdateColor(alpha);
        }

    }

    void UpdateColor(byte alpha)
    {
        gameObject.GetComponent<Image>().color = new Color32(14, 40, 138, alpha);
    }
}
