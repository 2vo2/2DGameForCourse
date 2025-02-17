using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    public Rigidbody2D BulletRigidbody => _rigidbody2D;
}

