using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _playerAnimator;

    private readonly int _idleHashAnimation = Animator.StringToHash("PlayerIdle");
    private readonly int _runHashAnimation = Animator.StringToHash("PlayerRun");
    private readonly int _jumpHashAnimation = Animator.StringToHash("PlayerJump");

    private void Update()
    {
        FlipCharacter();
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        if (!_playerMover.IsGrounded)
        {
            _playerAnimator.CrossFade(_jumpHashAnimation, 0f);
        }
        else if (_playerInput.HorizontalInput == 0f)
        {
            _playerAnimator.CrossFade(_idleHashAnimation, 0f);
        }
        else
        {
            _playerAnimator.CrossFade(_runHashAnimation, 0f);
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
