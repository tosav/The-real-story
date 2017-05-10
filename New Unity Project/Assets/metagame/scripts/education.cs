using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class education : MonoBehaviour {

	void Update() {
        if (PlayerPrefs.HasKey("start") == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
        }
    }

}
