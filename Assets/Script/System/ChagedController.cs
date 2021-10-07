using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChagedController : MonoBehaviour
{
    void OnEnable()
    {
        this.gameObject.GetComponent<Image>().DOFade(0.2f, 1.5f).SetLoops(-1, LoopType.Yoyo).SetLink(gameObject);
    }
}
