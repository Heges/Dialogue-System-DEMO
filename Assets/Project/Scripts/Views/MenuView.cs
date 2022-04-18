using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : BaseView
{
    public override void Initialize()
    {
        
    }

    public void OnClickStart() 
    {
        SceneTransition.instance.SetTransition(() => ViewManager.Show<GameView>());
    }

    public void OnClickSaveLoad()
    {
        ViewManager.Show<SaveLoadView>();
    }

    public void OnClickSettings()
    {
        ViewManager.Show<SettingsView>();
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
