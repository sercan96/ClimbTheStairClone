using System;
using UnityEngine;
using UnityEngine.UI;

public class Range : MonoBehaviour
{
    public GameObject MyRangeCanvas;
    public Text CylinderScoreText;

    private double _score;
    private float _riseValueY=0.2f;
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
        _score = 100;
    }
    
    public void IncreaseCylinderLength()
    {
        _riseValueY += 0.1f;
        _riseMyRange = 0.2f;
        
        transform.localScale = new Vector3(transform.localScale.x,_riseValueY,transform.localScale.z);
        transform.position = new Vector3(transform.position.x,_riseValueY , transform.position.z);
        
        MyRangeCanvas.transform.position = new Vector3(MyRangeCanvas.transform.position.x, 
            MyRangeCanvas.transform.position.y + _riseMyRange, MyRangeCanvas.transform.position.z);
    }

    public void IncreaseCylinderScore()
    {
        _score -= 0.2f;
        _score = Math.Round(_score,2);
        CylinderScoreText.text ="-" + _score + "m";
    }
}
