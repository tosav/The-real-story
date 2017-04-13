using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class meta : MonoBehaviour
{


    private void OnMouseDown()
    {
        SceneManager.LoadScene("metagame");
    }
}
