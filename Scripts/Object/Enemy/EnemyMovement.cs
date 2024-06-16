using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxDistanceToPoint;
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private Sounds _sounds;
    [SerializeField] private EnemyAnimation _animation;

    private int _currentPoint = 0;
    private float _delay = 3;
    private bool _isMove = false;
    private State _state;
    private Vector2 _pointPosition;


    private void OnEnable()
    {
        _state = State.Idle;
    }

    private void Update()
    {
        _pointPosition = new Vector2(_wayPoints[_currentPoint].position.x, _wayPoints[_currentPoint].position.y);
        float distance = Vector2.Distance(transform.position, _pointPosition);

        _isMove = distance > _maxDistanceToPoint;

        if (_isMove)
        {
            _state = State.Move;
            Move();
            _animation.FlipSprite(_pointPosition.x, transform.position.x);
        }
        else
        {
            if (TimeIsOver())
            {
                GetWayPoint();
            }

            _state = State.Idle;
        }

        _animation.PlayAnimation(_isMove);
        _sounds.PlaySound(_state);
    }

    private void GetWayPoint()
    {
        _currentPoint = (++_currentPoint) % _wayPoints.Length;
    }

    private bool TimeIsOver()
    {
        float maxDelay = 3;

        _delay -= Time.deltaTime;

        if (_delay < 0)
        {
            _delay = maxDelay;
            return true;
        }

        return false;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _pointPosition, _moveSpeed * Time.deltaTime);
    }
}
