using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    private DataManager _dataManager;

    void Start()
    {
        _dataManager = DataManager.Instance;
    }
    
    public void ContinueBtn()
    {
        SceneManager.LoadScene(0);

    }
    
    
    public bool IgnoreUI()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);

        #region Comment Line
        // for (int i = 0; i < raycastResults.Count; i++)
        // {
        //     if (raycastResults[i].gameObject.GetComponent<IgnoreGameUI>() != null)
        //     {
        //         raycastResults.RemoveAt(i);
        //         i++;
        //     }
        // }
        #endregion
        
        return raycastResults.Count > 0;
    }
}
