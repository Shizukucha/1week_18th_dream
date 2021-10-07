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
                audioSource.PlayOneShot(JUN_se[0]);//�u�X�^�[�g�v�u�^�C�g���ցv�u���g���C�v
                break;

            case 1:
                audioSource.PlayOneShot(JUN_se[1]);// SE�����p
                break;

            case 2:
                audioSource.PlayOneShot(JUN_se[2]);//�o�N������H�ׂ�Ƃ��̉�
                break;
            case 10:
                audioSource.PlayOneShot(JUN_se[3]);//�T�L���o�X�̍U����
                break;
            case 4:
                audioSource.PlayOneShot(JUN_se[4]);//�j�̎q�ɒe������������
                break;
            case 5:
                audioSource.PlayOneShot(JUN_se[5]);//�^�C���A�b�v��
                break;
            case 6:
                audioSource.PlayOneShot(JUN_se[6]);//���[��i���U���g��ʑJ�ډ��j
                break;
            case 7:
                audioSource.PlayOneShot(JUN_se[7]);//�ӂ��i���U���g��ʑJ�ډ��j
                break;
            case 8:
                audioSource.PlayOneShot(JUN_se[8]);//ZZZ�i���U���g��ʑJ�ډ��j
                break;




        }



    }


}
