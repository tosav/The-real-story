﻿using UnityEngine;
using System.Collections;


public class hope : MonoBehaviour
{
    private bool draggingItem = false;
    private GameObject draggedObject;
    private Vector2 touchOffset;
   
    void Update ()
    {
        if (HasInput)
        {
            DragOrPickUp();
        }
        else
        {
            if (draggingItem)
                DropItem();
        }
    }
     
    Vector2 CurrentTouchPosition
    {
        get
        {
            Vector2 inputPos;
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return inputPos;
        }
    }
 
    private void DragOrPickUp()
    {
        var inputPosition = CurrentTouchPosition;
    // (hit.transform! = NULL && hit.transform.tag ="prefab")
        if (draggingItem)
        {
            draggedObject.transform.position = inputPosition + touchOffset;
        }
        else
        {
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
            if (touches.Length > 0)
            {
                var hit = touches[0];
                if (hit.transform != null )
                { if (hit.transform != null && hit.transform.tag == "prefab"){
                    draggingItem = true;
                    draggedObject = hit.transform.gameObject;
					touchOffset = (Vector2)hit.transform.position - inputPosition;}
                    //draggedObject.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
                }
            }
        }
    }
 
    private bool HasInput
    {
        get
        {
            // returns true if either the mouse button is down or at least one touch is felt on the screen
            return Input.GetMouseButton(0);
        }
    }
 
    void DropItem()
    {
        draggingItem = false;
       // draggedObject.transform.localScale = new Vector3(1f,1f,1f);
    }
	
	void OnCollisionEnter2D(Collision2D coll)
		{
			if (coll.gameObject.CompareTag("panel"))
			{
            draggedObject.GetComponent<SpriteRenderer>().color = new Color(200.0f, 20f, 10f, 0.1f);
        }
			
		}
}
