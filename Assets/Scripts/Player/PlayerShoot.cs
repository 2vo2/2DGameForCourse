using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    public bool IsShooting { get; private set; }

    private void Update()
    {
        IsShooting = _playerInput.LeftMouseButtonInput;
    }
}