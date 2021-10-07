using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPanel : MonoBehaviour
{

    //public GameObject fadePnaleObj;


    public void OnClickHowToButton() 
    {
        gameObject.SetActive(true);

        //StartCoroutine(OnClickHowToButtonCO());
    }

    /*
    private IEnumerator OnClickHowToButtonCO() 
    {
        fadePnaleObj.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        fadePnaleObj.gameObject.SetActive(false);

        gameObject.SetActive(true);

    }
    */

    public void OnCllickCloseButtonOnHowToPanel() 
    {
        gameObject.SetActive(false);

    }


}
