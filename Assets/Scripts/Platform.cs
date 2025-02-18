using UnityEngine;

public class Platform : MonoBehaviour, IHittable
{
    [SerializeField] private StrayBullet _strayBulletPrefab;
    
    public void Hit()
    {
    }

    public void Hit(Vector2 hitPoint)
    {
        Instantiate(_strayBulletPrefab, hitPoint, Quaternion.identity);
    }
}
