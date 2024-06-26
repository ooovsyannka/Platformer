using UnityEngine;

[RequireComponent( typeof(Animations))]

public class EnemyAnimation : MonoBehaviour 
{
    private Animations _animations;

    private void Awake()
    {
        _animations = GetComponent<Animations>();
    }

    public void PlayAnimation(bool isMove)
    {
        _animations.PlayAnimationMove(isMove);
    }
}