using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    public void Move(Vector2 pointPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, pointPosition, _moveSpeed * Time.deltaTime);
        TurnByDirection(pointPosition.x);
    }

    private void TurnByDirection(float targetPositionX)
    {
        float maxAngle = 180;

        if (targetPositionX < transform.position.x)
            transform.rotation = Quaternion.Euler(0, maxAngle, 0);
        else if (targetPositionX > transform.position.x)
            transform.rotation = Quaternion.identity;
    }
}