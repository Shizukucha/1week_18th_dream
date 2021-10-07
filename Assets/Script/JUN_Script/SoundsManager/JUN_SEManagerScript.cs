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
                audioSource.PlayOneShot(JUN_se[0]);//「スタート」「タイトルへ」「リトライ」
                break;

            case 1:
                audioSource.PlayOneShot(JUN_se[1]);// SE調整用
                break;

            case 2:
                audioSource.PlayOneShot(JUN_se[2]);//バクが夢を食べるときの音
                break;
            case 10:
                audioSource.PlayOneShot(JUN_se[3]);//サキュバスの攻撃音
                break;
            case 4:
                audioSource.PlayOneShot(JUN_se[4]);//男の子に弾があたった音
                break;
            case 5:
                audioSource.PlayOneShot(JUN_se[5]);//タイムアップ音
                break;
            case 6:
                audioSource.PlayOneShot(JUN_se[6]);//ららーん（リザルト画面遷移音）
                break;
            case 7:
                audioSource.PlayOneShot(JUN_se[7]);//ふつう（リザルト画面遷移音）
                break;
            case 8:
                audioSource.PlayOneShot(JUN_se[8]);//ZZZ（リザルト画面遷移音）
                break;




        }



    }


}
