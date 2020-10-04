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

    public GameObject startingLifeObj;
    StartingLifeManeger startingLife;

    // Start is called before the first frame update
    void Start()
    {
        startingLife = startingLifeObj.GetComponent<StartingLifeManeger>();
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

    public void Load()
    {
        life = PlayerPrefs.GetInt(key + "life", 20);
        lifeText.text = life.ToString();
    }

    public void Reset()
    {
        life = startingLife.Get();
        lifeText.text = life.ToString();
        Save();
    }

    public void DiceRoll()
    {
        // 1〜6の値を表示する
        lifeText.text = Random.Range(1,7).ToString();
    }
}
