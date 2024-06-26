using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxDistanceToPoint;
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private Sounds _sounds;

    private int _currentPoint = 0;
    private bool _isMoving ;
    private float _delay = 3;
    private Vector2 _pointPosition;
    private State _state;
    private Coroutine _changePosition;
    private Coroutine _moveTo;

    private void Start()
    {
        _changePosition = StartCoroutine(ChangeTarget());
    }

    private void Update()
    {
        _enemyAnimation.PlayAnimation(_isMoving);
        _sounds.PlaySound(_state);
    }

    private IEnumerator MoveTo()
    {
        _state = State.Move;
        _isMoving = true;

        while (Vector2.Distance(transform.position, _pointPosition) > _maxDistanceToPoint)
        {
            _enemyMover.Move(_pointPosition);
            yield return null;
        }

        if (_changePosition != null)
            StopCoroutine(_changePosition);

        _changePosition = StartCoroutine(ChangeTarget());
    }

    private IEnumerator ChangeTarget()
    {
        _isMoving = false;
        _state = State.Idle;
        
        yield return new WaitForSeconds(_delay);

        _currentPoint = (++_currentPoint) % _wayPoints.Length;
        _pointPosition = new Vector2(_wayPoints[_currentPoint].position.x, _wayPoints[_currentPoint].position.y);

        if (_moveTo != null)
            StopCoroutine(_moveTo);

        _moveTo = StartCoroutine(MoveTo());
    }
}
