using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back : MonoBehaviour {

void OnMouseUp(){
 GameObject.Find("квадрат").GetComponent<Animation>().Play("back");
}
}
