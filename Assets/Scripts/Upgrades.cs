using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public static float StartCounter;
    
    void Start()
    {
        StartCounter = 0.2f;
    }
    public void SpeedUpgraded(float speedCount) // 0.01f
    {
        Debug.Log(" Speed Selected!");
        StartCounter -= speedCount;
        Player.Animator.speed += speedCount * 4f;
        DataManager.Instance.MyMoney(40);
    }

    public void StaminaUpgraded(int amount) // +2
    {
        Player.Stamina += amount;
        Player.MaxStaminaValue += amount;
        DataManager.Instance.MyMoney(amount * 20);
    }
    
}
