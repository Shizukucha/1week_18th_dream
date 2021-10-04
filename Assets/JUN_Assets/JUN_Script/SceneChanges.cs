using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanges: MonoBehaviour
{
	private static int currentIndex; // ???????V?[?????????????????i?[

	private void Start()
	{
		currentIndex = SceneManager.GetActiveScene().buildIndex; // ???????V?[??????????????
	}

	public void SceneTransitions()
	{
		if (currentIndex != 2)
		{
			SceneManager.LoadScene(currentIndex + 1);
		}
		else
		{
			SceneManager.LoadScene(0);

		}
	}

	public void GoToGame()
	{
		if (currentIndex == 2)
		{
			SceneManager.LoadScene(currentIndex - 1);
		}
	}


}
