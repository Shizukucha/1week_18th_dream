using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JUN_SEManagerScript : MonoBehaviour
{
    public Slider JUN_SEslider;
    public AudioClip[] JUN_se;
    public static JUN_SEManagerScript instance;

    private AudioSource audioSource;
    private void Awake()
    {
        // AudioManagerインスタンスが存在しなければ生成
        // 存在すればDestroy，return
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();

        JUN_SEslider.onValueChanged.AddListener(value => audioSource.volume = value);
    }

    public void JUN_SettingPlaySE(int SENumber)
    {

        switch (SENumber)
        {
            default:
            case 0:
                audioSource.PlayOneShot(JUN_se[0]);//スタート音かつSE調整用
                break;

            case 1:
                audioSource.PlayOneShot(JUN_se[1]);// 親ネズミが食われる
                break;

            case 2:
                audioSource.PlayOneShot(JUN_se[2]);//チーズ取得用
                break;

            case 3:
                audioSource.PlayOneShot(JUN_se[3]);//子ネズミが猫に捕食される
                break;
            case 4:
                audioSource.PlayOneShot(JUN_se[4]);//クリア時
                break;




        }



    }


}
