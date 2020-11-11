using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextFader : MonoBehaviour
{
    public Vector3 scaleMax;
    public Vector3 scaleMin;
    public int fontSizeMax;
    public int fontSizeMin;
    public float duration;

    private float time;
    private Vector3 deltaScale = Vector3.zero;
    private float deltaFontSize = 0;
    private float diffFontSize;
    private float deltaAlpha = 0;

    private Text text = default;

    private void Start() {
        text = GetComponent<Text>();
        time = duration;
    }

    private void OnEnable() {
        text = GetComponent<Text>();
        FadeOut();
    }

    private void Update() {
        if( time < duration ){
            time += Time.deltaTime;
            /*
            diffFontSize  += (deltaFontSize * Time.deltaTime);
            Debug.Log(diffFontSize);
            if( diffFontSize > 1.0f ){
                text.fontSize += (int)Mathf.Floor(diffFontSize); 
                diffFontSize -= (int)Mathf.Floor(diffFontSize);
            }
            */
            text.fontSize += (int)(deltaFontSize * Time.deltaTime);
            if( text.fontSize > fontSizeMax ){
                text.fontSize = fontSizeMax;
            }
            else if( text.fontSize < fontSizeMin ){
                text.fontSize = fontSizeMin;
            }

            transform.localScale += deltaScale * Time.deltaTime;
            
            Color newColor = text.color;
            newColor.a += deltaAlpha * Time.deltaTime;
            text.color = newColor;
        }
    }

    public void FadeOut () {
        text.fontSize = fontSizeMax;
        transform.localScale = scaleMin;
        var c = text.color;
        c.a = 1;
        text.color = c;
        deltaScale = ( scaleMax - scaleMin ) / duration;
        deltaFontSize = -( fontSizeMax - fontSizeMin ) / duration;
        Debug.Log( deltaFontSize);
        deltaAlpha = -1/duration;
        time = 0;
    }

    public void FadeIn() {
        deltaScale = -( scaleMax - scaleMin ) / duration;
        deltaFontSize = ( fontSizeMax - fontSizeMin ) / duration;
        deltaAlpha = 1/duration;
        time = 0;
    }
}
