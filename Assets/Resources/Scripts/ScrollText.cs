using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollText : MonoBehaviour
{
    private int _currentValue = 0;
    private int currentValue {
        set {
            _currentValue = value;
            int setVal = value + 2;
            foreach( Text text in texts){
                text.text = setVal.ToString();
                setVal--;
            }
        }
        get {
            return _currentValue;
        }
    }
    public int targetValue = 0;

    public RectTransform scrollBase;
    private Vector2 startPos;
    public Vector2 scrollUnit;
    public Vector2 speed;

    public List<Text> texts;

    private void Awake() {
        currentValue = 0;
        startPos = scrollBase.anchoredPosition;
    }

    private void Update() {

        int diff = targetValue - currentValue;
        Vector2 scrollValue;

        if( diff >= 3 ){
            scrollValue = -speed*Time.deltaTime*3;
        }
        else if( diff > 0 ){
            scrollValue = -speed*Time.deltaTime*diff;
        }
        else if( diff < 0 ){
            scrollValue = -speed*Time.deltaTime*diff;
        }
        else if ( diff <= -3 ){
            scrollValue = speed*Time.deltaTime*3;
        }
        else { // (diff == 0)
            Vector2 diffPos = scrollBase.anchoredPosition-startPos;
            if( diffPos.y > 10 ){
                scrollValue = -diffPos;
            }
            else if( diffPos.y < -10 ){
                scrollValue = -diffPos;
            }
            else {
                return;
            }
        }

        scrollBase.anchoredPosition += scrollValue;
        
        // 一定以上スクロールしたら数値を変える
        if( scrollBase.anchoredPosition.y > scrollUnit.y ){
            scrollBase.anchoredPosition -= scrollUnit;
            currentValue -= 1;
        }
        else if( scrollBase.anchoredPosition.y < -scrollUnit.y ){
            scrollBase.anchoredPosition += scrollUnit;
            currentValue += 1;
        }
    }
}
