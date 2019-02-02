using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// パネルの開閉用スクリプト
// 追加するオブジェクトには"isOpen"のboolで開閉するAnimatorを
// Componentに追加しておく
public class PanelSwitcher : MonoBehaviour
{
    Animator animator;
    const string PARAM = "isOpend";//animatorのパラメータ名
    const string KEY = "isOpen"; //開閉状態を保存するためのキー
    public bool saveStatus = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Load();
    }

    // パネルの開閉状態切替
    // 開いていれば閉じる
    // 閉じていれば開く
    public void Toggle()
    {
        bool isOpen = animator.GetBool(PARAM);
        // パネルを開くアニメーション起動
        animator.SetBool(PARAM, !isOpen);
        Save();
    }

    // パネルを開く
    public void Open()
    {
        bool isOpen = animator.GetBool(PARAM);
        // 既に開いていたら何もしない
        if( isOpen == true ){
            return;
        }
        // パネルを開くアニメーション起動
        animator.SetBool(PARAM, true);
        Save();
    }

    // パネルを閉じる
    public void Close()
    {
        bool isOpen = animator.GetBool(PARAM);
        // 既に開いていたら何もしない
        if( isOpen == false ){
            return;
        }
        // パネルを開くアニメーション起動
        animator.SetBool(PARAM, false);
        Save();
    }

    public void Save()
    {
        if (saveStatus == true)
        {
            bool isOpen = animator.GetBool(PARAM);
            PlayerPrefs.SetInt(name + KEY, (isOpen ? 1 : 0));
        }
    }

    public void Load()
    {
        if (saveStatus == true)
        {
            bool isOpen = (PlayerPrefs.GetInt(name + KEY, 0) == 1);
            animator.SetBool(PARAM, isOpen);
        }
    }
}
