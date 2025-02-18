using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootSpeed;
    [SerializeField] private float _shootDelay;

    private float _delayTimer;
    
    public bool IsShooting { get; private set; }

    private void Update()
    {
        _delayTimer += Time.deltaTime;
        
        if (_playerInput.LeftMouseButtonInput && _playerMover.IsGrounded)
        {
            IsShooting = true;
            
            if (_delayTimer >= _shootDelay)
            {
                _delayTimer = 0f;
                Shoot();
            }
        }
        else
        {
            IsShooting = false;
        }
    }

    private void Shoot()
    {
        var newBullet = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);

        if (transform.localScale.x == 1f)
        {
            newBullet.BulletRigidbody.AddForce(Vector2.right * _shootSpeed);
            FlipBullet(newBullet, 1f);
        }
        else
        {
            newBullet.BulletRigidbody.AddForce(Vector2.left * _shootSpeed);
            FlipBullet(newBullet, -1f);
        }
    }

    private static void FlipBullet(Bullet bullet, float scaleX)
    {
        var bulletScale = bullet.transform.localScale;
        bulletScale.x = scaleX;
        bullet.transform.localScale = bulletScale;
    }
}