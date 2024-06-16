using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    private State _state;
    private Rigidbody2D _rigidbody;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private InputKeyboard _input;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Sounds _sounds;
    [SerializeField] private PlayerAnimation _animation;

    private bool _isMove;
    private bool _isJump;
    private bool _isFall;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _state = State.AnyState;
    }

    private void Update()
    {
        _isMove = Mathf.Abs(_input.HorizontalInput) > 0 && InGround();
        _isJump = _rigidbody.velocity.y > 0 && InGround() == false;
        _isFall = _rigidbody.velocity.y < 0 && InGround() == false;

        _sounds.PlaySound(_state);
        _animation.PlayAnimation(_isMove, _isJump, _isFall);

        ChangeState();
    }

    private void FixedUpdate()
    {
        Jump();
        Move();
        _animation.FlipSprite(_input.HorizontalInput);
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_input.HorizontalInput * _moveSpeed * Time.fixedDeltaTime, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (_input.IsPressUpArrow && InGround())
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void ChangeState()
    {
        if (_isMove && InGround())
        {
            _state = State.Move;
        }
        else
        {
            _state = State.AnyState;
        }
    }

    private bool InGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_groundCheck.position, Vector2.down, 0);

        if (hit)
        {
            if (hit.transform.TryGetComponent(out Ground ground))
            {
                return true;
            }
        }

        return false;
    }
}
