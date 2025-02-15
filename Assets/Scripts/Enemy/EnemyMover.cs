using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed;

    private bool _changeDirection;

    public bool ChangeDirection => _changeDirection;
    
    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = _changeDirection ? Vector2.left * _speed : Vector2.right * _speed;

        var distanceToPointA = Vector2.Distance(transform.position, _pointA.position);
        var distanceToPointB = Vector2.Distance(transform.position, _pointB.position);
        
        if (distanceToPointA <= 1.1f)
        {
            _changeDirection = false;
        }
        if (distanceToPointB <= 1.1f)
        {
            _changeDirection = true;
        }
    }
}
