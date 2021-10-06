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


    private int currentIndex; // ���݂̃V�[�������ԖڂȂ̂��i�[

    private void Awake()
    {
        // AudioManager�C���X�^���X�����݂��Ȃ���ΐ���
        // ���݂����Destroy�Creturn
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
        currentIndex = SceneManager.GetActiveScene().buildIndex; // ���݂̃V�[���̏��Ԃ��擾
    }

    public void JUN_TransitionBGM(int currentIndex)
    {

        audioSource.Stop();

        Debug.Log("���̃V�[����" + currentIndex);
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

    private IEnumerator WaitPlaySe()  //���U���g��ʉ�����̎��Ԓ����p
    {

        yield return new WaitForSeconds(1.1f);
        audioSource.Play();
    }


}
