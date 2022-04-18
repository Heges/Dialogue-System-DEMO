using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public static Background instnace;

    public Sprite DeffaultBG => deffault;

    [SerializeField] private Image background;
    [SerializeField] private Sprite deffault;

   private void Awake()
    {
         if(instnace == null)
        {
            instnace = this;
        }
    }

    public void SetBackground(Sprite sprite)
    {
        background.gameObject.SetActive(true);
        background.sprite = sprite;
    }
}
