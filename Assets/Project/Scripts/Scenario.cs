using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario
{
    public bool IsOver => isDialogueOver;
    public Sprite Background => background;

    private readonly Sprite background;
    private readonly Speech speech;

    private int indexLine;

    private bool isDialogueOver;

    public Scenario(Sprite bckSprite, Speech spech)
    {
        background = bckSprite;
        speech = spech;
    }

    public void Process()
    {
        var character = CharacterManager.instnace.GetCharacter(speech.line[indexLine].nameChar);
        character.Active();
        character.Say(speech.line[indexLine].text, speech.line[indexLine].mood);
        character.SetPosition(GetPosition(speech.line[indexLine].place));

        indexLine++;
        if(indexLine >= speech.line.Length)
        {
            isDialogueOver = true;
            return;
        }
    }

    private Vector2 GetPosition(EPLACE place)
    {
        switch (place)
        {
            case EPLACE.OUT:
                return Vector2.left;
            case EPLACE.LEFT:
                return Vector2.zero;
            case EPLACE.RIGHT:
                return Vector2.right;
            case EPLACE.CENTER:
                return new Vector2(0.5f, 0);
            default:
                return default;
        }
    }
}
