using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition instance;

    [SerializeField] private Animator animator;

    private System.Action callback;
    private Sprite background;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SetTransition(System.Action action, Sprite bckGround = null)
    {
        callback = action;
        background = bckGround == null ? background??Background.instnace.DeffaultBG : bckGround;
        animator.SetTrigger("FadeIN");
    }

    public void OnEndFadeIN()
    {
        Background.instnace.SetBackground(background);
        callback?.Invoke();
        animator.SetTrigger("FadeOUT");
    }

    public void OnEndFadeOUT()
    {
        //callback?.Invoke();
        //Debug.Log("CALLBACK");
    }
}
