using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animations _animations;

    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void PlayAnimation(bool isMove, bool isJump, bool isFall)
    {
        _animations.PlayAnimationMove(isMove);
        _animations.PlayAnimationJump(isJump);
        _animations.PlayAnimationFall(isFall);
    }

    public void FlipSprite(float direction)
    {
        if (direction < 0)
            _spriteRenderer.flipX = true;

        else if (direction > 0)
            _spriteRenderer.flipX = false;
    }
}