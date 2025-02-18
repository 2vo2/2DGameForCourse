using UnityEngine;

public class EnemyAnimation : MonoBehaviour, IFadeable
{
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private SpriteRenderer _enemySpriteRenderer;

    private void Update()
    {
        _enemySpriteRenderer.flipX = !_enemyMover.ChangeDirection;
    }

    public void SetFade()
    {
        _enemyAnimator.SetLayerWeight(1, 1f);
        Invoke(nameof(ResetFade), 1f);
    }

    public void ResetFade()
    {
        _enemyAnimator.SetLayerWeight(1, 0f);
    }
}