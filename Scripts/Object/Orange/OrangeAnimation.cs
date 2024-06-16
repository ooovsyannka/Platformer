using UnityEngine;

[RequireComponent(typeof(Animations))]

public class OrangeAnimation : MonoBehaviour
{
    private Animations _animations;

    private void Awake()
    {
        _animations = GetComponent<Animations>();
    }

    public void PlayAnimation(bool isDie)
    {
        _animations.PlayAnimationDie(isDie);
    }
}
