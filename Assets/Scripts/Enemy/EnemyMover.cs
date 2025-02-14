using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        var distanceToPointA = Vector2.Distance(transform.position, _pointA.position);
        var distanceToPointB = Vector2.Distance(transform.position, _pointB.position);
        
        if (distanceToPointA <= distanceToPointB)
        {
            if (distanceToPointA <= 0.5f)
            {
                _rigidbody2D.linearVelocity = Vector2.right * _speed;
            }
            else
            {
                _rigidbody2D.linearVelocity = Vector2.left * _speed;
            }
        }
        else
        {
            if (distanceToPointB <= 0.5f)
            {
                _rigidbody2D.linearVelocity = Vector2.left * _speed;
            }
            else
            {
                _rigidbody2D.linearVelocity = Vector2.right * _speed;
            }
        }
    }
}
