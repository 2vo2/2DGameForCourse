using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed;

    private bool _changeDirection;
    
    private void FixedUpdate()
    {
        if (_changeDirection)
        {
            _rigidbody2D.linearVelocity = Vector2.left * _speed;   
            print("Go Left!");
        }
        else
        {
            _rigidbody2D.linearVelocity = Vector2.right * _speed;
            print("Go Right!");
        }
        
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
