using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingLifeManeger : MonoBehaviour
{

    Text Shape;
    Text Shadow;
    private int life;
    const string key = "StartingLife";

    // Start is called before the first frame update
    void Start()
    {
        Shape = transform.Find("Shape").gameObject.GetComponent<Text>();
        Shadow = transform.Find("Shadow").gameObject.GetComponent<Text>();
        Load();
    }

    public void UpDown(int value)
    {
        life += value;
        Shape.text = life.ToString();
        Shadow.text = life.ToString();
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetInt(key, life);
    }

    void Load()
    {
        life = PlayerPrefs.GetInt(key, 20);
        Shape.text = life.ToString();
        Shadow.text = life.ToString();
    }

}
