﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonManager : MonoBehaviour
{
    public string playerName;
    public GameObject[] counters;

    const int MAX = 10;
    const string KEY = "poison";

    int poison;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    public void Set( int value )
    {
        poison = value;

        for (int i=0; i < MAX; i++)
        {
            // value 以下ならAvtiveにする
            // valueより大きい場合は非Activeにする
            bool activeFlag = (i < value);
            counters[i].SetActive(activeFlag);
        }
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetInt(playerName + KEY, poison);
    }

    void Load()
    {
        Set(PlayerPrefs.GetInt(playerName + KEY, 0));
    }

    public void Reset()
    {
        Set(0);
    }


}
