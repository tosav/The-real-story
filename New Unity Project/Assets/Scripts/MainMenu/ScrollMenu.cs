using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScrollMenu : MonoBehaviour {
	//идеально
    public float speedX = 0f ,speedY = 5f, checkPosX = 0f, checkPosY = 0f;
    private void FixedUpdate()
    {
		if (speedY >= 0) {
			if (this.GetComponent<RectTransform>().offsetMin.y < checkPosY) {
				this.GetComponent<RectTransform>().offsetMin += new Vector2 (0, speedY);
				this.GetComponent<RectTransform>().offsetMax += new Vector2 (0, speedY);
			} 
		} else {
			if (this.GetComponent<RectTransform>().offsetMin.y > checkPosY) {
				this.GetComponent<RectTransform>().offsetMin += new Vector2 (0, speedY);
				this.GetComponent<RectTransform>().offsetMax += new Vector2 (0, speedY);
			} 
		}
		if (speedX >= 0) {
			if (this.GetComponent<RectTransform>().offsetMin.x < checkPosX) {
				this.GetComponent<RectTransform>().offsetMin += new Vector2 (0, speedX);
				this.GetComponent<RectTransform>().offsetMax += new Vector2 (0, speedX);
			} 
		} else {
			if (this.GetComponent<RectTransform>().offsetMin.x > checkPosX) {
				this.GetComponent<RectTransform>().offsetMin += new Vector2 (0, speedX);
				this.GetComponent<RectTransform>().offsetMax += new Vector2 (0, speedX);
			} 
		}
    }
}
