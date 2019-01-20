using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePanelManager : MonoBehaviour
{
    public GameObject lifeTextObj;
    public string key;
    private Text lifeText;
    private int life;

    // Start is called before the first frame update
    void Start()
    {
        lifeText = lifeTextObj.GetComponent<Text>();
        Load();
    }

    public void UpDown(int value)
    {
        life += value;
        lifeText.text = life.ToString();
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetInt(key + "life", life);
    }

    void Load()
    {
        life = PlayerPrefs.GetInt(key + "life", 20);
        lifeText.text = life.ToString();
    }

    void Reset()
    {
        life = 20;
        lifeText.text = life.ToString();
        Save();
    }
}
