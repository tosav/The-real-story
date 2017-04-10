using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camera : MonoBehaviour
{
    public GameObject one;
    bool isTouched;
    public bool isPC;
    Ray ray;
    RaycastHit hit;

    void Update() {

        one = GameObject.FindWithTag("prefab");

        if (!isPC)
        { 
      //  foreach (GameObject obj in one)
      //  {
            Touch touch = Input.GetTouch(0);
            ray = Camera.main.ScreenPointToRay(touch.position);
            if( Input.touchCount > 0)
            {
                if (Physics.Raycast(ray, out hit, 300) && hit.collider.gameObject == one)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        Vector3 cameraTransform = Camera.main.transform.InverseTransformPoint(0, 0, 0);
                        one.transform.position = Camera.main.ScreenToWorldPoint( new Vector3(touch.position.x, touch.position.y, cameraTransform.z));
                    }
                }
            }
      //  }
        }

        if (isPC)
        {
        //    foreach (GameObject obj in one)
         //   {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Input.GetMouseButton(0))
                {
                    if (Physics.Raycast(ray, out hit, 300) && hit.collider.gameObject == one)
                    {
                        Vector3 cameraTransform = Camera.main.transform.InverseTransformPoint(0, 0, 0);
                    one.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraTransform.z));
                    }
              //  }
            }
        }
}



/*private void Update()
    {
        ray = Camera.main.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("prefeb"))
            {
                Debug.Log("Касание объекта");
            }

        }
    }*/
}

