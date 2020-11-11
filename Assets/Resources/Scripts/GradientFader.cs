using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UiEffect;

public class GradientFader : MonoBehaviour
{
    public float duration;

    public GradientAlpha gradient;
    private float alphaDiff;
    private float timer = 0;

    private void FadeIn() {
        // 左から右に現れる
        gradient.alphaTop = 1;
        gradient.alphaBottom = 1;
        gradient.alphaLeft = 1;
        gradient.alphaRight = 0;
        gradient.gradientOffsetHorizontal = 1;
        gradient.gradientOffsetVertical = 1;
        alphaDiff = 2/duration;
        timer = duration;
    }

    private void FadeOut() {
        // 左から右に消える
        gradient.alphaTop = 1;
        gradient.alphaBottom = 1;
        gradient.alphaLeft = 0;
        gradient.alphaRight = 1;
        gradient.gradientOffsetHorizontal = 1;
        gradient.gradientOffsetVertical = 1;
        alphaDiff = 2/duration;
        timer = duration;
    }

    private void OnEnable() {
        FadeIn();
    }

    void Update() {
        if( timer > 0 ) {
            gradient.gradientOffsetHorizontal -= alphaDiff*Time.deltaTime;
            timer -= Time.deltaTime;
        }
        
    }
}
