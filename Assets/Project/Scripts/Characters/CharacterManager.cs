using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instnace;

    private readonly Dictionary<string, Character> charList = new Dictionary<string, Character>();

    private void Awake()
    {
        if(instnace == null)
        {
            instnace = this;
        }
    }

    public Character GetCharacter(string name)
    {
        Character character = null;
        charList.TryGetValue(name, out character);
        if (character)
        {
            return character;
        }
        else
        {
            character = CreateCharacter(name);
            charList.Add(name, character);
            return character;
        }
    }

    private Character CreateCharacter(string name)
    {
        return CharacterCreationService.GetCharacter(name);
    }
}
