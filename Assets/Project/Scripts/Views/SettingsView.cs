using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsView : BaseView
{
    public override void Initialize()
    {
        
    }

    public void OnClickMenu()
    {
        ViewManager.Show<MenuView>();
    }
}
