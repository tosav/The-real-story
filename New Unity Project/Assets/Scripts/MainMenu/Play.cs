using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public GameObject buttons;
    public Text GameName;
    public Image Earth;
    public GameObject gamebuttons;

    private void OnMouseDown()
    {
        GameName.GetComponent<ScrollMenu>().speed = 10f;
        GameName.GetComponent<ScrollMenu>().checkPosY = 130f;
        buttons.GetComponent<ScrollMenu>().speed = -10f;
        buttons.GetComponent<ScrollMenu>().checkPosY = -200f;
        Earth.GetComponent<ScrollMenu>().speed = -10f;
        Earth.GetComponent<ScrollMenu>().checkPosY = -400f;
        gamebuttons.GetComponent<ScrollMenu>().speed = 10f;
        gamebuttons.GetComponent<ScrollMenu>().checkPosY = 0;
    }
}
