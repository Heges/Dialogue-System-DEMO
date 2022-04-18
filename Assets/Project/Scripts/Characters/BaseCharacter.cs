using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter : ScriptableObject
{
    [SerializeField] protected string characterName;
    [SerializeField] protected Sprite characterImage;
    [SerializeField] protected Sprite[] characterExpressions;
    [SerializeField] protected bool left;

    public abstract void Say(string say, EMOOD express = EMOOD.NORMAL);

    public abstract Sprite GetEmotion(EMOOD exprs);
}
