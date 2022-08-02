using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
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
    
    void Start()
    {
        Instance = this;
        Debug.Log(Money);
        GetMoney();
    }

    void Update()
    {
        CanvasUı.MyMoneyTxt.text = Money.ToString();
        SaveMoney();
    }
    public void MyMoney(int amount)
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

    
}
