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
    public void Level1SpeedUpgraded()
    {
        Debug.Log("Level1 Speed Selected!");
        
        StartCounter -= .1f;
        Player.Animator.speed += .4f;
    }
    
}
