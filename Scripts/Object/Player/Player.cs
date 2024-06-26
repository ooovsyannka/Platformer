using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerAnimation _playerAnimations;
    [SerializeField] private Sounds _sounds;

    private bool _isJump;
    private bool _isMove;
    private bool _isFall;
    private State _state;

    private void FixedUpdate()
    {
        float horizontalDirection = _inputReader.HorizontalInput;

        _isMove = horizontalDirection != 0;
        _isJump = _mover.IsJump() && _groundDetector.InGround() == false;
        _isFall = _mover.IsFall() && _groundDetector.InGround() == false;

        if (_isMove)
        {
            _mover.Move(horizontalDirection);

            if (_groundDetector.InGround())
                _state = State.Move;
            else
                _state = State.AnyState;
        }
        else
        {
            _state = State.AnyState;
        }

        if (_inputReader.IsJump && _groundDetector.InGround())
        {
            _mover.Jump();
        }

        _sounds.PlaySound(_state);
        _playerAnimations.PlayAnimation(_isMove, _isJump, _isFall);
    }
}
