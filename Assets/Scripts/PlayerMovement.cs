using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float PlayerRot;
    [SerializeField] private Player _player;
    public float Speed;
    private float _stairsRotY;
    private float _stairPosY;
    private float _counter;

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
        _counter = 0.1f; // speed görevi yapacak.
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
        }
    }
    
    
    private bool Timer()
    {
        if (_counter >= 0)
        {
            _counter -= Time.deltaTime;
            return false;
        }
        return true;
    }
    

    public void PlayerTransformSituation()
    {
        transform.position = Climb(0.2f);
        transform.rotation = PlayerDirection(PlayerRot);
        _counter = 0.1f;
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
