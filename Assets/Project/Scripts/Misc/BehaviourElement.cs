using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourElement : MonoBehaviour
{
    public virtual void Active() => gameObject.SetActive(true);

    public virtual void Hide() => gameObject.SetActive(false);
}
