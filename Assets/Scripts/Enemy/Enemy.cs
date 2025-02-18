using UnityEngine;

public class Enemy : MonoBehaviour, IHittable
{
    [SerializeField] private EnemyAnimation _enemyAnimation;
    
    public void Hit()
    {
        _enemyAnimation.SetFade();
    }

    public void Hit(Vector2 hitPoint)
    {
    }
}
