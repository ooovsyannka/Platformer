using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animations))]

public class EnemyAnimation : MonoBehaviour 
{
    private Animations _animations;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animations = GetComponent<Animations>();
    }
    public void PlayAnimation(bool isMove)
    {
        _animations.PlayAnimationMove(isMove);
    }

    public void FlipSprite(float targetPosition, float currentDirection)
    {
        if (targetPosition < currentDirection)
            _spriteRenderer.flipX = true;

        else if (targetPosition > currentDirection)
            _spriteRenderer.flipX = false;
    }
}