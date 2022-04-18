using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public void OnClickNext()
    {
        Debug.Log("Next");
    }

    public void OnClickAuto()
    {
        Debug.Log("Auto");
    }

    public void OnClickSkip()
    {
        Debug.Log("Skip");
    }

    public void OnClickHistory()
    {
        Debug.Log("History");
    }

    public void OnClickMenu()
    {
        Debug.Log("Menu");
        ViewManager.Show<MenuView>();
    }
}
