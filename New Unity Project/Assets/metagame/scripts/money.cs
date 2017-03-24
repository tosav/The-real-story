using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour {

    string str_m;

    void Start()
    {
        FileInfo f = new FileInfo("Assets/metagame/file/money.txt");
    }

    void Update()
    {
        p_m();
        gameObject.GetComponent<Text>().text = str_m;
    }

    void p_m()
    {
        StreamReader sr1 = new StreamReader("Assets/metagame/file/money.txt");
        str_m = "";
        while (!sr1.EndOfStream)
        {
            str_m += sr1.ReadLine();
        }
        sr1.Close();
    }
}
