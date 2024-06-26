using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(new Vector2(0, _jumpForce));
    }

    public void Move(float direction)
    {
        transform.Translate(new Vector2(_speed * direction * Time.fixedDeltaTime,0),Space.World);
        TurnByDirection(direction);
    }

    public bool IsFall()
    {
        if (_rigidbody.velocity.y < 0)
            return true;

        return false;
    }

    public bool IsJump()
    {
        if (_rigidbody.velocity.y > 0)
            return true;

        return false;
    }

    private void TurnByDirection(float direction)
    {
        float maxAngle = 180;

        if (direction < 0)
            transform.rotation = Quaternion.Euler(0, maxAngle, 0);

        if (direction > 0)
            transform.rotation = Quaternion.identity;
    }
}
