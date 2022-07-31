using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    public Transform StairPos;
    public GameObject SpawnCylinderObj;
    public Transform CylinderRange;

    private bool _state;
    private float _stairPosY;    
    private float _stairsRotY;     
    private float _stairPosZ;
    private float _stairPosX;

    void OnEnable()
    {
        EventManager.MousePressEvent += SpawnStairs;
    }
    
    void OnDisable()
    {
        EventManager.MousePressEvent -= SpawnStairs;
    }
    
    void Start()
    {
        Instance = this;
        _stairPosY= 0.2f;
        SpawnCylinder();
    }
    
    public Vector3 StairsTransform(float posY)
    {
        _stairPosY += posY;
        return new Vector3(StairPos.transform.position.x, _stairPosY,StairPos.transform.position.z);
    }
    
    public Quaternion Direction(float rotY)
    {
        _stairsRotY += rotY;
        return Quaternion.AngleAxis(_stairsRotY, Vector3.up);  
    }

    public void SpawnStairs()
    {
        ObjectPooler.Instance.SpawnFromPool("Stair", StairsTransform(0.2f), Direction(15f));
    }
    
    
    public void SpawnCylinder()
    {
        Instantiate(SpawnCylinderObj, CylinderRange.position, CylinderRange.rotation,StairPos.transform);
    }
    
   
}
