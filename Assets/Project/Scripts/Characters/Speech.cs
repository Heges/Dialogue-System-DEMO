using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="New Scenario", menuName ="Scenario/Conservation")]
public class Speech : ScriptableObject
{
    public Sprite background;
    public Line[] line;
}

[Serializable]
public enum EMOOD
{
    NORMAL,
    ANGRY,
    SAD,
    HAPPY,
    CONFUSED,
    DISSAPOINTED,
    BLUSHES
}

[Serializable]
public enum EPLACE 
{
    OUT,
    LEFT,
    RIGHT,
    CENTER,
}

[Serializable]
public struct Line 
{
    public string nameChar;
    public EPLACE place;
    [TextArea(2, 5)]
    public string text;
    public EMOOD mood;
}
