using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSEPlayer : MonoBehaviour
{
    public void PlaySE(int playNumber)
    {
        JUN_SEManagerScript.instance.JUN_SettingPlaySE(playNumber);
    }
}
