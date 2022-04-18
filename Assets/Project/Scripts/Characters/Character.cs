using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName ="Character", menuName ="Characters/Character")]
public class Character : BaseCharacter
{
    private CharacterPanel myPanel;

    public void Initialize(CharacterPanel mPanel)
    {
        myPanel = mPanel;
    }

    public override void Say(string say, EMOOD express = EMOOD.NORMAL)
    {
        //Active();

        DialogSystem.Say(say, characterName, Hide);
        myPanel.SetCharacterImage(characterImage);
        myPanel.SetCharacterExpression(GetEmotion(express));
        //myPanel.SetCharacterExpression(GetEmotion(expres));

        //DialogSystem.ShowSpeeker(characterImage, GetEmotion(expres), left);
        //DialogSystem.ShowSpeeker(characterImage, GetEmotion(EExpressions.NORMAL), left);
        //DialogSystem.ShowSpeeker(characterImage, characterExpressions[Random.Range(0, characterExpressions.Length)], left);
    }

    public override Sprite GetEmotion(EMOOD exprs)
    {
        switch (exprs)
        {
            case EMOOD.NORMAL:
                return characterExpressions[0];
            case EMOOD.ANGRY:
                return characterExpressions[1];
            case EMOOD.SAD:
                return characterExpressions[2];
            case EMOOD.HAPPY:
                return characterExpressions[3];
            case EMOOD.CONFUSED:
                return characterExpressions[4];
            case EMOOD.DISSAPOINTED:
                return characterExpressions[5];
            case EMOOD.BLUSHES:
                return characterExpressions[6];
            default:
                return characterExpressions[0];
        }
    }

    public void SetPosition(Vector2 target)
    {
        myPanel.SetPosition(target);
    }

    public void Active() => myPanel.Active();

    public void Hide() => myPanel.Hide();
}
