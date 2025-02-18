using UnityEngine;

public class Enemy : MonoBehaviour, IHittable
{
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private int _health;
    
    public void Hit()
    {        
        if (_health > 0)
        {
            _health--;
            _enemyAnimation.SetFade();

            if (_health <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void Hit(Vector2 hitPoint)
    {
    }
}
