using UnityEngine;

[RequireComponent(typeof(Animation), typeof(SpriteRenderer))]

public class PlayerAnimation : MonoBehaviour
{
    private Animations _animations;

    private void Awake()
    {
        _animations = GetComponent<Animations>();
    }

    public void PlayAnimation(bool isMove, bool isJump, bool isFall)
    {
        _animations.PlayAnimationMove(isMove);
        _animations.PlayAnimationJump(isJump);
        _animations.PlayAnimationFall(isFall);
    }
}