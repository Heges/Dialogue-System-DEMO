using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpeechPanel : BehaviourElement
{
    public TextMeshProUGUI TextMeshProUGUI => speakerName;
    public TextMeshProUGUI Dialog => dialog;

    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private TextMeshProUGUI dialog;

    public void SetDialogText(string text)
    {
        dialog.text = text;
    }

    public void SetSpeakerName(string name)
    {
        speakerName.text = name;
    }

    public void SetFontSize(int size)
    {
        dialog.fontSize = size;
        speakerName.fontSize = size;
    }
}
