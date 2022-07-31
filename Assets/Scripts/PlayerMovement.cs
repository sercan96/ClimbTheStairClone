using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float PlayerRot;
    [SerializeField] private Player _player;
    
    public static float Counter;
    
    private float _stairsRotY;
    private float _stairPosY;
    
    void OnEnable()
    {
        EventManager.MousePressEvent += PlayerTransformSituation;
    }
    void OnDisable()
    {
        EventManager.MousePressEvent -= PlayerTransformSituation;
    }
    
    void Start()
    {
        Counter = Upgrades.StartCounter; // speed görevi yapacak.
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!Timer()) return;
            
            EventManager.MousePressEvent.Invoke();
        }
        else
        {
            _player.IdleAnimation();
            _player.RaiseStamine();
        }
    }
    
    
    private bool Timer()
    {
        if (Counter >= 0)
        {
            Counter -= Time.deltaTime;
            return false;
        }
        return true;
    }
    

    public void PlayerTransformSituation()
    {
        transform.position = Climb(0.2f);
        transform.rotation = PlayerDirection(PlayerRot);
        Counter = Upgrades.StartCounter;
    }
    
    
    public Vector3 Climb(float posY)
    {
        _stairPosY += posY;
        return new Vector3(transform.position.x, _stairPosY, transform.position.z);
    }

    
    public Quaternion PlayerDirection(float rotY)
    {
        _stairsRotY += rotY;
        return Quaternion.AngleAxis(_stairsRotY, Vector3.up );  
    }
    
}
