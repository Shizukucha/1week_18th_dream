using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Omake : MonoBehaviour
{
    public Animator anim;
    public GameObject ukiukiObj;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNikoNikoButton() 
    {
        anim.SetTrigger("Niko");
    }

    public void showUkiUkiObj() 
    {
        ukiukiObj.SetActive(true);
    }

    public void offUkiUkiObj()
    {
        ukiukiObj.SetActive(false);
    }

}
