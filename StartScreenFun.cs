using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenFun : MonoBehaviour
{
	public GameObject rules;

	void Update()
	{
		if (Input.GetKeyDown ("space")) {
			SceneManager.LoadScene (1);
		}
		if (Input.GetKeyDown (KeyCode.I)) {
			Instantiate (rules);
		}
	}
}
