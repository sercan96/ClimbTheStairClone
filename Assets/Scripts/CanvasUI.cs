using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    public static CanvasUI Instance;
    public bool GameActive = false;
    public Transform TapToStartObj;
    public Ease EasyType;
    public Text MyMoneyTxt;
    public GameObject WinCanvas;
    public GameObject LoseCanvas;
    public GameUI GameUı;
    
    
    void Start()
    {
        Instance = this;
        InvokeRepeating("TapToStartScale",1f,2f);
    }

    void Update()
    {
        if (GameActive) return;

        if (Input.GetMouseButtonDown(0) && !GameUı.IgnoreUI())
        {
            TapToStartObj.gameObject.SetActive(false);
            GameActive = true;
        }
    }

    private void TapToStartScale()
    {
        TapToStartObj.DOScale(1.3f, 1f).SetEase(EasyType)
            .OnComplete(() => TapToStartObj.DOScale(1f, 0.5f)).SetEase(EasyType);
    }

    public void WinPanel()
    {
        WinCanvas.SetActive(true);
    }
    
    public void LosePanel()
    {
        LoseCanvas.SetActive(true);
    }


}
