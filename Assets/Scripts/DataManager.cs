using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    public Range Range;
    public CanvasUI CanvasUı;
    public static DataManager Instance;
    public int Money = 100;



    void OnEnable()
    {
        EventManager.MousePressEvent += IncreaseMoneyAmount;
    }
    
    void OnDisable()
    {
        EventManager.MousePressEvent -= IncreaseMoneyAmount;
    }

    void Awake()
    {
        GetMoney();
        GetCylinder();
    }
    void Start()
    {
        Instance = this;
        Debug.Log(Money);

    }

    void Update()
    {
        CanvasUı.MyMoneyTxt.text = Money.ToString();
        SaveMoney();
        SaveCylinder();
    }
    public void MainMoney(int amount)
    {
        if (Money <= amount) return;
        Money -= amount;
    }

    public void IncreaseMoneyAmount()
    {
        Money++;
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt("Money",Money);
        PlayerPrefs.Save();
    }
    
    public void GetMoney()
    {
        Money = PlayerPrefs.GetInt("Money");
    }

    public void SaveCylinder()
    {
        Range.TargetCylinderState();
        
        PlayerPrefs.SetFloat("CylPositionY",Range.TargetCylinder.transform.position.y);  
        PlayerPrefs.SetFloat("CylLocalScaleY",Range.TargetCylinder.transform.localScale.y);
        
        PlayerPrefs.SetFloat("CvsPositionY",Range.TargetCanvas.transform.position.y);
        PlayerPrefs.SetFloat("CvsLocalScaleY",Range.TargetCanvas.transform.localScale.y);

    }

    public void GetCylinder()
    {
        float cylPositionY =PlayerPrefs.GetFloat("CylPositionY");
        float cylLocalScaleY =PlayerPrefs.GetFloat("CylLocalScaleY");
        
        float cvsPositionY =PlayerPrefs.GetFloat("CvsPositionY");
        float cvsLocalScaleY =PlayerPrefs.GetFloat("CvsLocalScaleY");

        Vector3 targetPos = new Vector3(Range.TargetCanvas.transform.position.x, cylPositionY,
            Range.TargetCanvas.transform.position.z);
        
        Vector3 targetScale = new Vector3(Range.TargetCanvas.transform.localScale.x, cylLocalScaleY,
            Range.TargetCanvas.transform.localScale.z);
        
        Vector3 canvasPos = new Vector3(Range.TargetCanvas.transform.position.x, cvsPositionY,
            Range.TargetCanvas.transform.position.z);
        
                
        Vector3 canvasScale = new Vector3(Range.TargetCanvas.transform.localScale.x, cvsLocalScaleY,
            Range.TargetCanvas.transform.localScale.z);
        
    }
    

    
}
