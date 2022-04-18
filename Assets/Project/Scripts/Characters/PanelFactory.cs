using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PanelFactory", menuName ="Factories/PanelFactory")]
public class PanelFactory : ScriptableObject
{
    [SerializeField] private CharacterPanel charPanel;

    public CharacterPanel Get()
    {
        var obj = Instantiate(charPanel, RectTransform.FindObjectOfType<Canvas>().transform);
        obj.Hide();
        return obj;
    }
}
