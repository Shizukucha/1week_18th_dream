using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanges: MonoBehaviour
{
	private static int currentIndex; // ���݂̃V�[�������ԖڂȂ̂��i�[

	private void Start()
	{
		currentIndex = SceneManager.GetActiveScene().buildIndex; // ���݂̃V�[���̏��Ԃ��擾
	}

	public void SceneTransitions()
    {
		if(currentIndex != 2)
        {
			SceneManager.LoadScene(currentIndex + 1);
		}
        else
        {
			SceneManager.LoadScene(0);

		}


	}

}
