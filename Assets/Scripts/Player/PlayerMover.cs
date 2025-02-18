using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    public bool IsGrounded { get; private set; }
    public bool IsMoving { get; private set; }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Platform platform))
        {
            foreach (var contact in other.contacts)
            {
                IsGrounded = (contact.normal.y >= -1f && contact.normal.y <= -0.998f) || contact.normal.y >= 0.1f;
                break;
            }
        }
        else
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        IsGrounded = false;
    }

    private void Move()
    {
        Moving();
        
        var movementVector = new Vector2(_playerInput.HorizontalInput * _moveSpeed, _rigidbody2D.linearVelocity.y);

        _rigidbody2D.linearVelocity = movementVector;
    }

    private void Moving()
    {
        IsMoving = _playerInput.HorizontalInput != 0f;
    }

    private void Jump()
    {
        if (_playerInput.SpaceInput && IsGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
