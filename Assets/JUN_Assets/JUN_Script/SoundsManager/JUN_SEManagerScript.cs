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
                audioSource.PlayOneShot(JUN_se[0]);//�X�^�[�g������SE�����p
                break;

            case 1:
                audioSource.PlayOneShot(JUN_se[1]);// �e�l�Y�~���H����
                break;

            case 2:
                audioSource.PlayOneShot(JUN_se[2]);//�`�[�Y�擾�p
                break;

            case 3:
                audioSource.PlayOneShot(JUN_se[3]);//�q�l�Y�~���L�ɕߐH�����
                break;
            case 4:
                audioSource.PlayOneShot(JUN_se[4]);//�N���A��
                break;




        }



    }


}
