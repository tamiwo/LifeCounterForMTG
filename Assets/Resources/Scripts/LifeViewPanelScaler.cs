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

    public void ChangeScale()
    {
        const string paramName = "isMinimum";
        bool isMinimum = animator.GetBool(paramName);
        animator.SetBool(paramName, !isMinimum);
    }
}
