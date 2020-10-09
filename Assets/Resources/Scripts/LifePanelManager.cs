using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePanelManager : MonoBehaviour
{
    public ScrollText lifeText;
    public string key;
    private int life;

    public GameObject startingLifeObj;
    StartingLifeManeger startingLife;

    // Start is called before the first frame update
    void Start()
    {
        startingLife = startingLifeObj.GetComponent<StartingLifeManeger>();
        Load();
    }

    public void UpDown(int value)
    {
        life += value;
        lifeText.targetValue = life;
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetInt(key + "life", life);
    }

    public void Load()
    {
        life = PlayerPrefs.GetInt(key + "life", 20);
        lifeText.targetValue = life;
    }

    public void Reset()
    {
        life = startingLife.Get();
        lifeText.targetValue = life;
        Save();
    }

    public void DiceRoll()
    {
        // 1〜6の値を表示する
        lifeText.targetValue = Random.Range(1,7);
    }
}
