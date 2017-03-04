using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
    }
    private void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
