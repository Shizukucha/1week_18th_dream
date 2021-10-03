using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JUN_BGMManagerScript : MonoBehaviour
{
    public Slider JUN_BGMslider;
    public AudioClip[] JUN_clips;
    AudioSource audioSource;
    public static JUN_BGMManagerScript instance;


    private int currentIndex; // 現在のシーンが何番目なのか格納

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
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        JUN_BGMslider.onValueChanged.AddListener(value => audioSource.volume = value);
        currentIndex = SceneManager.GetActiveScene().buildIndex; // 現在のシーンの順番を取得
    }

    public void JUN_TransitionBGM(int currentIndex)
    {

        audioSource.Stop();

        Debug.Log("今のシーンは" + currentIndex);
        if (currentIndex == 2) 
        { 
            audioSource.clip = JUN_clips[0];
           
            StartCoroutine(WaitPlaySe());

        }
        else 
        {
            audioSource.clip = JUN_clips[currentIndex + 1];
            audioSource.Play();

        }

    }

    private IEnumerator WaitPlaySe()  //リザルト画面音入りの時間調整用
    {

        yield return new WaitForSeconds(1.1f);
        audioSource.Play();
    }


}
