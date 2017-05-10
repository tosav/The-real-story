using UnityEngine;

public class clicker : MonoBehaviour
{
    void OnMouseDown()
    {
		 if (PlayerPrefs.HasKey("start") == true){
        GameObject.Find("panel").GetComponent<Animation>().Play("build");
		 }
    }
}

