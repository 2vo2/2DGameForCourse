using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed;

    public bool ChangeDirection { get; private set; }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = 
            ChangeDirection ? DirectionToPoint(_pointA.position) * _speed : DirectionToPoint(_pointB.position) * _speed;
        
        if (DistanceToPoint(_pointA.position) <= 0.1f)
        {
            ChangeDirection = false;
        }
        if (DistanceToPoint(_pointB.position) <= 0.1f)
        {
            ChangeDirection = true;
        }
    }

    private Vector2 DirectionToPoint(Vector3 pointPosition)
    {
        return (pointPosition - transform.position).normalized;
    }
    
    private float DistanceToPoint(Vector3 pointPosition)
    {
        return Vector3.Distance(pointPosition, transform.position);
    }
}
