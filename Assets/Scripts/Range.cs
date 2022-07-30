using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Range : MonoBehaviour
{
    public GameObject Canvas;
    public Text CylinderScoreText;
    private float _score;
    
    private float _riseValueY;

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
        Canvas = GameObject.Find("MyRange");
        CylinderScoreText = GameObject.Find("MyScore").GetComponent<Text>();
    }

    void Update()
    {
        Canvas.transform.position = transform.position;
    }

    public void IncreaseCylinderLength()
    {
        transform.localScale = new Vector3(transform.localScale.x,_riseValueY,transform.localScale.z);
        _riseValueY += 0.2f;
    }

    public void IncreaseCylinderScore()
    {
        _score += 0.2f;
        CylinderScoreText.text = _score.ToString(CultureInfo.InvariantCulture);
    }
}
