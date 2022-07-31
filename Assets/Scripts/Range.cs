using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Range : MonoBehaviour
{
    public GameObject MyRangeCanvas;
    public Text CylinderScoreText;
    
    private float _score;
    private float _riseValueY;
    private float _riseMyRange;

    void OnEnable()
    {
        EventManager.MousePressEvent += IncreaseCylinderLength;
        EventManager.MousePressEvent += IncreaseCylinderScore;
    }  
    void OnDisable()
    {
        EventManager.MousePressEvent -= IncreaseCylinderLength;
        EventManager.MousePressEvent -= IncreaseCylinderScore;
    }

    void Start()
    {
        MyRangeCanvas = GameObject.Find("MyRange");
        CylinderScoreText = GameObject.Find("MyScore").GetComponent<Text>();
    }
    
    public void IncreaseCylinderLength()
    {
        _riseValueY += 0.2f;
        _riseMyRange = 0.2f;
        
        transform.localScale = new Vector3(transform.localScale.x,_riseValueY,transform.localScale.z);
        
        MyRangeCanvas.transform.position = new Vector3(MyRangeCanvas.transform.position.x, 
            MyRangeCanvas.transform.position.y + _riseMyRange, MyRangeCanvas.transform.position.z);
    }

    public void IncreaseCylinderScore()
    {
        _score += 0.2f;
        CylinderScoreText.text = _score + " m";
    }
}
