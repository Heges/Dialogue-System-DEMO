using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterPanel : BehaviourElement
{
    public Character MyCharacter => myCharacter;
    public Image CharacterImage => characterImage;

    public Vector2 AnchorPadding { get { return root.anchorMax - root.anchorMin; } }

    private Character myCharacter;

    [SerializeField] private Image characterImage;
    [SerializeField] private Image characterImageExpression;

    private Vector3 myRotation;
    private RectTransform root;

    public void Initialize(Character c)
    {
        myCharacter = c;
        root = GetComponent<RectTransform>();
        SetPosition(Vector2.left);
    }

    private void Awake()
    {
        myRotation = characterImage.rectTransform.eulerAngles;
    }

    public void SetCharacterImage(Sprite sprite)
    {
        characterImage.sprite = sprite;
    }

    public void SetCharacterExpression(Sprite sprite)
    {
        characterImageExpression.sprite = sprite;
    }

    public void EffectShow()
    {
        gameObject.transform.DORotate(new Vector3(0, 360, 0), 1f, RotateMode.FastBeyond360);
        //characterImage.transform.DORotate(new Vector3(0, 360 + myRotation.y,0), 1f, RotateMode.FastBeyond360);
        //characterImage.transform.DOShakePosition(1f, strength: new Vector3(2, 2, 0), vibrato: 4, randomness: 4, snapping: false, fadeOut: true);
    }

    public override void Active()
    {
        //characterImage.gameObject.SetActive(true);
        base.Active();
        EffectShow();
    }

    public override void Hide()
    {
        base.Hide();
        //characterImage.gameObject.SetActive(false);
    }

    private bool isMoving;
    private IEnumerator moving;
    public void MoveTo(Vector2 Target, float speed, bool smooth = true)
    {
        StopMoving();
        moving = Moving(Target, speed, smooth);
        StartCoroutine(moving);
    }

    public void SetPosition(Vector2 target)
    {
        targetPosition = target;
        Vector2 padding = AnchorPadding;
        float maxX = 1f - padding.x;
        float maxY = 1f - padding.y;
        Vector2 minAnchorTarget = new Vector2(maxX * targetPosition.x, maxY * targetPosition.y);

        root.anchorMin = minAnchorTarget;
        root.anchorMax = root.anchorMin + padding;
    }

    public void StopMoving()
    {
        if (isMoving)
        {
            StopCoroutine(moving);
        }
        isMoving = false;
        moving = null;
    }

    private Vector2 targetPosition;
    private IEnumerator Moving(Vector2 target, float speed, bool smooth)
    {
        isMoving = true;
        targetPosition = target;
        Vector2 padding = AnchorPadding;
        float maxX = 1f - padding.x;
        float maxY = 1f - padding.y;
        Vector2 minAnchorTarget = new Vector2(maxX * targetPosition.x, maxY * targetPosition.y);

        speed *= Time.deltaTime;

        while (root.anchorMin != minAnchorTarget)
        {
            root.anchorMin = Vector2.MoveTowards(root.anchorMin, minAnchorTarget, speed);
            root.anchorMax = root.anchorMin + padding;
            yield return new WaitForEndOfFrame();
        }
        StopMoving();
    }

}
