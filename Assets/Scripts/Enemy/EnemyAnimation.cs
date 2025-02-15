using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private SpriteRenderer _enemySpriteRenderer;

    private void Update()
    {
        _enemySpriteRenderer.flipX = !_enemyMover.ChangeDirection;
    }
}