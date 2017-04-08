﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSong : MonoBehaviour {
    private static MainSong instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
