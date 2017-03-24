using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

	void OnMouseDown(){
		gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
	}
}
