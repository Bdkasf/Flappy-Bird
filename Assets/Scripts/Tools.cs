using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools
{
    #region 单例模式
    #endregion
    static Tools ins;

    public static Tools Ins
    {
        get
        {
            if(ins == null)
            {
                ins = new Tools();
            }
            return ins;
        }
    }

    Tools()
    {

    }

    public void ShowUI(GameObject uiOb)
    {
        uiOb.SetActive(true);
        uiOb.GetComponent<CanvasGroup>().alpha = 0;
        uiOb.GetComponent<UImanager>().ShowUI();
    }

    public void HideUI(GameObject uiOb)
    {  
        uiOb.GetComponent<UImanager>().HideUI();
    }
}