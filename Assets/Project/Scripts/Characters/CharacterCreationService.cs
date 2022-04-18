using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class CharacterCreationService
{
    public static Character GetCharacter(string name)
    {
        var scriptblHero = Resources.Load($"Characters/{name}/{name}") as Character;
        var panelFactory = Resources.Load($"PanelFactory") as PanelFactory;
        var instance = panelFactory.Get();
        instance.Initialize(scriptblHero);
        scriptblHero.Initialize(instance);
        instance.GetComponent<RectTransform>().SetSiblingIndex(1);
        instance.name = scriptblHero.name;
        return scriptblHero;
    }
}
