using UnityEngine;

public static class AnimationData 
{
    public static class Params
    {
        public static readonly int IsMove = Animator.StringToHash(nameof(IsMove));
        public static readonly int IsJump = Animator.StringToHash(nameof(IsJump));
        public static readonly int IsFall = Animator.StringToHash(nameof(IsFall));
        public static readonly int IsDie = Animator.StringToHash(nameof(IsDie));
    }
}