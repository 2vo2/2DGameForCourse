using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerShoot _playerShoot;
    [SerializeField] private Animator _playerAnimator;

    private readonly int _idleHashAnimation = Animator.StringToHash("PlayerIdle");
    private readonly int _runHashAnimation = Animator.StringToHash("PlayerRun");
    private readonly int _jumpHashAnimation = Animator.StringToHash("PlayerJump");
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
        {
            _playerAnimator.SetLayerWeight(1, 1f);
            Invoke(nameof(ResetFade), 1f);
        }
    }

    private void ResetFade()
    {
        _playerAnimator.SetLayerWeight(1, 0f);
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
        else if (_playerShoot.IsShooting)
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
            ChangePlayerScale(1f);
        }
        else if (_playerInput.LeftInput)
        {
            ChangePlayerScale(-1f);
        }
    }

    private void ChangePlayerScale(float scaleX)
    {
        var playerScale = transform.localScale;
        playerScale.x = scaleX;
        transform.localScale = playerScale;
    }
}
