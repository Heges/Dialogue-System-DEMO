using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogSystem : MonoBehaviour
{
    public static DialogSystem instance;

    public static event Action OnDialogOver;

    public bool IsSpeaking => isSpeaking;

    [SerializeField] private SpeechPanel speechPanel;

    private static readonly Stack<string> history = new Stack<string>();

    private IEnumerator speaking;
    private IEnumerator readText;
    private bool isSpeaking = false;

    private string speech;
    private bool skip;
    private Action callbackFunc;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Say(string something, string speeker = "", Action callback = null)
    {
        instance.speech = something;
        history.Push(something);
        instance.callbackFunc = callback;

        if (instance.speaking == null)
        {
            instance.speaking = instance.Speak(something, speeker, callback);
            instance.StartCoroutine(instance.speaking);
        }
    }

    public static void StopSpeak()
    {
        if (instance.isSpeaking)
        {
            if (instance.skip)
            {
                //skip
                instance.skip = false;
                instance.StopCoroutine(instance.readText);
                instance.readText = null;
                instance.isSpeaking = false;
                instance.speaking = null;
                instance.skip = false;
                instance?.callbackFunc();
                OnDialogOver?.Invoke();
            }
            else
            {
                //stop speak show text wait time
                instance.skip = true;
                if (instance.readText == null)
                {
                    instance.readText = instance.ReadText();
                }
                instance.StopCoroutine(instance.speaking);
                instance.StopCoroutine(instance.readText);
                instance.StartCoroutine(instance.readText);
            }
        }
    }

    private IEnumerator ReadText()
    {
        speechPanel.SetDialogText(speech);
        float tempTime = 0;
        while (true)
        {
            if (GameView.IsGameOn)
            {
                tempTime += Time.deltaTime;
            }

            yield return null;

            if (tempTime >= 3f)
            {
                break;
            }
        }
        readText = null;
        isSpeaking = false;
        speaking = null;
        skip = false;
        instance?.callbackFunc();
        OnDialogOver?.Invoke();
    }

    private IEnumerator Speak(string speech, string speaker = "", Action callback = null)
    {
        isSpeaking = true;
        speechPanel.Active();
        speechPanel.SetSpeakerName(speaker);
        speechPanel.SetDialogText("");
        while (speechPanel.Dialog.text != speech && !skip)
        {
            if (GameView.IsGameOn)
            {
                speechPanel.Dialog.text += speech[speechPanel.Dialog.text.Length];
                yield return new WaitForSeconds(0.05f);
            }
            else
            {
                yield return null;
            }
        }
        yield return new WaitForSeconds(3f);
        isSpeaking = false;
        speaking = null;
        skip = false;
        callback?.Invoke();
        OnDialogOver?.Invoke();
    }

    public void Active() => speechPanel.gameObject.SetActive(true);

    public void Hide() => speechPanel.gameObject.SetActive(false);
}
