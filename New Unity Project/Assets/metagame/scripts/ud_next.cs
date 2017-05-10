using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ud_next : MonoBehaviour {

    void OnMouseUp()
    {
        PlayerPrefs.SetString("start", "true");
        PlayerPrefs.Save();
    }
	
		void Update() {
        if (PlayerPrefs.HasKey("start") == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
        }
    }
}
