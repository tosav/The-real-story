using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backmenu : MonoBehaviour {
	void OnMouseUp()
	{
	SceneManager.LoadScene("main");
	}
}
