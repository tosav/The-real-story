using UnityEngine;

public class clicker_l : MonoBehaviour {

    void OnMouseDown()
    {
        GameObject.Find("panel").GetComponent<Animation>().Play("build_l");
    }
}
