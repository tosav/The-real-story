using UnityEngine;

public class clicker : MonoBehaviour
{
    void OnMouseDown()
    {
        GameObject.Find("panel").GetComponent<Animation>().Play("build");
    }
}

