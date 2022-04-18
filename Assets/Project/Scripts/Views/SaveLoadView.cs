using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveLoadView : BaseView
{
    public override void Initialize()
    {
        
    }

    public void OnClickMenu()
    {
        ViewManager.Show<MenuView>();
    }

    public void OnClickToSave()
    {
        Debug.Log("SAVE");
    }
    
    public void OnClickLoad()
    {
        Debug.Log("LOAd");
    }

    public void OnClickDelete()
    {
        Debug.Log("DELETE");
    }
}
