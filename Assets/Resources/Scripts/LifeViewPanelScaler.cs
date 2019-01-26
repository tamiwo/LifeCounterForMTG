using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeViewPanelScaler : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void ChangeScale()
    {
        const string name = "isMinimum";
        bool isMinimum = animator.GetBool(name);
        animator.SetBool(name, !isMinimum);
    }
}
