using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Omake_Panel : MonoBehaviour
{

    public void OnOmakePanel() 
    {

        gameObject.SetActive(true);
    }

    public void OffOmakePanel()
    {

        gameObject.SetActive(false);
    }
}
