using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour { 

    private void OnMouseDown()
    {
        print("Menu");
        SceneManager.LoadScene("main");
    }
}
