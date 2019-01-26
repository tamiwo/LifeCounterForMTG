using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject target;
    public GameObject[] others;
    Animator[] animators;
    const int TARGET = 0;
    const string PARAM = "isOpend";

    // Start is called before the first frame update
    void Start()
    {
        // targetが0番目、残りが1番目以降に入った配列を作る
        int length = others.Length + 1;
        animators = new Animator[length];

        animators[TARGET] = target.GetComponent<Animator>();
        for (int i = 1; i < length; i++)
        {
            animators[i] = others[i-1].GetComponent<Animator>();
        }
    }

    public void PushButton()
    {
        bool isOpen = animators[TARGET].GetBool(PARAM);

        if (isOpen == false)
        {
            // Open target panel
            animators[TARGET].SetBool(PARAM, true);
            // Close other panels
            for (int i = 1; i < animators.Length; i++)
            {
                animators[i].SetBool(PARAM, false);
            }
        }
        else
        {
            // Close target panel
            animators[TARGET].SetBool(PARAM, false);
        }
    }

}
