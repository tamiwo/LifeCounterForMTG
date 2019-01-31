using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// パネルの開閉用スクリプト
// 追加するオブジェクトには"isOpen"のboolで開閉するAnimatorを
// Componentに追加しておく
public class PanelSwitch : MonoBehaviour
{
    Animator animator;
    const string PARAM = "isOpend";//animatorのパラメータ名

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // パネルの開閉状態切替
    // 開いていれば閉じる
    // 閉じていれば開く
    public void Toggle()
    {
        bool isOpen = animator.GetBool(PARAM);
        // パネルを開くアニメーション起動
        animator.SetBool(PARAM, !isOpen);
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
    }

}
