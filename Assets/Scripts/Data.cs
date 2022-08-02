using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newData",menuName = "Data")]
public class Data : ScriptableObject
{
   public Vector3 CylPosition;
   public Vector3 CylLocalScale;

   public Vector3 CnvPosition;
   public Vector3 CnvLocalScale;
}
