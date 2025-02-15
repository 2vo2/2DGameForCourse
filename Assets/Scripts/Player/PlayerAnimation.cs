using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerShoot _playerShoot;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _playerAnimator;

    private readonly int _idleHashAnimation = Animator.StringToHash("PlayerIdle");
    private readonly int _runHashAnimation = Animator.StringToHash("PlayerRun");
    private readonly int _jumpHashAnimation = Animator.StringToHash("PlayerJump");
    private readonly int _fadeHashAnimation = Animator.StringToHash("PlayerFade");
    private readonly int _shootHashAnimation = Animator.StringToHash("PlayerShoot");
    private readonly int _runShootHashAnimation = Animator.StringToHash("PlayerRunShoot");

    private void Update()
    {
        FlipCharacter();
        HandleAnimations();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
            _playerAnimator.CrossFade(_fadeHashAnimation, 0f);
    }

    private void HandleAnimations()
    {
        if (!_playerMover.IsGrounded)
        {
            _playerAnimator.CrossFade(_jumpHashAnimation, 0f);
        }
        else if (_playerMover.IsMoving && _playerShoot.IsShooting)
        {
            _playerAnimator.CrossFade(_runShootHashAnimation, 0f);
        }
        else if (_playerMover.IsMoving)
        {
            _playerAnimator.CrossFade(_runHashAnimation, 0f);
        }
        else if (_playerShoot.IsShooting && !_playerMover.IsMoving)
        {
            _playerAnimator.CrossFade(_shootHashAnimation, 0f);
        }
        else
        {
            _playerAnimator.CrossFade(_idleHashAnimation, 0f);
        }
    }

    private void FlipCharacter()
    {
        if (_playerInput.RightInput)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_playerInput.LeftInput)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
