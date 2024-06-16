using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]

public class Animations : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimationMove(bool isMove )
    {
        _animator.SetBool(AnimationData.Params.IsMove, isMove);
    }

    public void PlayAnimationJump(bool isJump )
    {
        _animator.SetBool(AnimationData.Params.IsJump, isJump);
    }

    public void PlayAnimationFall(bool isFall )
    {
        _animator.SetBool(AnimationData.Params.IsFall, isFall);
    }

    public void PlayAnimationDie(bool isDie )
    {
        _animator.SetBool(AnimationData.Params.IsDie, isDie);
    }
}
