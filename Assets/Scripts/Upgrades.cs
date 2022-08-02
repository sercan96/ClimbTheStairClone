using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public static float StartCounter;
    public Button[] Buttons;
    
    void Start()
    {
        StartCounter = 0.2f;
    }
    public void SpeedUpgraded(float speedCount) // 0.01f
    {
        Debug.Log(" Speed Selected!");
        StartCounter -= speedCount;
        Player.Animator.speed += speedCount * 4f;
        DataManager.Instance.MainMoney(40);
        Buttons[0].interactable = false;
    }

    public void StaminaUpgraded(int amount) // +2
    {
        Player.Stamina += amount;
        Player.MaxStaminaValue += amount;
        DataManager.Instance.MainMoney(amount * 20);
        Buttons[2].interactable = false;
    }
    
}
