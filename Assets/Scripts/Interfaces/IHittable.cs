using UnityEngine;

public interface IHittable
{
    public void Hit();
    public void Hit(Vector2 hitPoint);
}