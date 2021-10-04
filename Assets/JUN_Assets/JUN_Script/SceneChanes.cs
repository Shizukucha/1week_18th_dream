using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanges: MonoBehaviour
{
	private static int currentIndex; // 現在のシーンが何番目なのか格納

	private void Start()
	{
		currentIndex = SceneManager.GetActiveScene().buildIndex; // 現在のシーンの順番を取得
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
