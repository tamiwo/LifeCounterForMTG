using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UiEffect;

public class GradientFader : MonoBehaviour
{
    public float duration;

    public GradientAlpha gradient;
    private float alphaDiff;
    private float fadeTimer = 0;
    private float timer = 0;

    public void FadeIn( float timeOffset = 0 ) {
        // 左から右に現れる
        gradient.alphaTop = 1;
        gradient.alphaBottom = 1;
        gradient.alphaLeft = 1;
        gradient.alphaRight = 0;
        gradient.gradientOffsetHorizontal = 1;
        gradient.gradientOffsetVertical = 1;
        alphaDiff = 2/duration;
        if ( timeOffset > 0 ) {
            timer = timeOffset;
        }
        fadeTimer = duration;
    }

    public void FadeOut( float timeOffset = 0 ) {
        // 左から右に消える
        gradient.alphaTop = 1;
        gradient.alphaBottom = 1;
        gradient.alphaLeft = 0;
        gradient.alphaRight = 1;
        gradient.gradientOffsetHorizontal = 1;
        gradient.gradientOffsetVertical = 1;
        alphaDiff = 2/duration;
        if ( timeOffset > 0 ) {
            timer = timeOffset;
        }
        fadeTimer = duration;
    }

    void Update() {
        if( timer > 0 ) {
            timer -= Time.deltaTime;
            return;
        }
        if( fadeTimer > 0 ) {
            gradient.gradientOffsetHorizontal -= alphaDiff*Time.deltaTime;
            fadeTimer -= Time.deltaTime;
        }
    }
}
