using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptiveText : MonoBehaviour
{
    [SerializeField] private int fontSize = 24;
    private static float deffaultResolution = 3000f;

    private SpeechPanel panel;

    private void Awake()
    {
        panel = GetComponent<SpeechPanel>();
    }

    private void Start()
    {
        panel.SetFontSize(fontSize);
        float totalCurrentResolution = Screen.height + Screen.width;
        float perc = totalCurrentResolution / deffaultResolution;
        int newFontSize = Mathf.RoundToInt((float)fontSize * perc);
        panel.SetFontSize(newFontSize);
    }
}
