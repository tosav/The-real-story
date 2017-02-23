using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMenu : MonoBehaviour {
    public float speed = 5f, checkPosX = 0f, checkPosY = 0f;
    private RectTransform rec;
    private void Start()
    {
        rec = GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (rec.offsetMin.y !=checkPosY)
        { 
            rec.offsetMin += new Vector2(0, speed);
            rec.offsetMax += new Vector2(0, speed);
        }
        /*if (rec.localPosition.x != checkPosX)
        {
            rec.localPosition += new Vector3(speed, 0);
        }*/
    }
}
