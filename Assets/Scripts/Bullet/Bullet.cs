using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    public Rigidbody2D BulletRigidbody => _rigidbody2D;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.Hit();
        }
        else if (other.TryGetComponent(out Platform platform))
        {
            var contactPoint = other.ClosestPoint(transform.position);
            platform.Hit(contactPoint);
        }
        
        gameObject.SetActive(false);

    }
}

