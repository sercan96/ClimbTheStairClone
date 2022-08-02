using System;
using UnityEngine;
using UnityEngine.UI;

public class Range : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject TargetCanvas;
    
    public GameObject TargetCylinder;
    public Text MainCylinderScoreText;
    public Text TargetCylinderScoreText;

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
        // MainCanvas = GameObject.Find("MyRange");
        // CylinderScoreText = GameObject.Find("MyScore").GetComponent<Text>();
        _score = 100;
    }

    
    public void IncreaseCylinderLength()
    {
        _riseValueY += 0.1f;
        _riseMyRange = 0.2f;
        
        transform.localScale = new Vector3(transform.localScale.x,_riseValueY,transform.localScale.z);
        transform.position = new Vector3(transform.position.x,_riseValueY , transform.position.z);
        
        MainCanvas.transform.position = new Vector3(MainCanvas.transform.position.x, 
            MainCanvas.transform.position.y + _riseMyRange, MainCanvas.transform.position.z);
    }

    public void IncreaseCylinderScore()
    {
        _score -= 0.2f;
        _score = Math.Round(_score,2);
        MainCylinderScoreText.text ="-" + _score + "m"; 
        TargetCylinderScoreText.text ="-" + _score + "m";
    }


    public void TargetCylinderState()
    {
        TargetCylinder.transform.position = transform.position;
        TargetCylinder.transform.localScale = transform.localScale;

        TargetCanvas.transform.position = MainCanvas.transform.position;
        TargetCanvas.transform.localScale = MainCanvas.transform.localScale;

        TargetCylinderScoreText = MainCylinderScoreText;
    }
}
