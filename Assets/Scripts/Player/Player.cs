using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private int _health;

    private int _coinScore;

    public event UnityAction<int> OnHealthChange;
    public event UnityAction<int> OnCoinScoreChange;

    private void Awake()
    {
        OnHealthChange?.Invoke(_health);
        OnCoinScoreChange?.Invoke(_coinScore);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (_health > 0)
            {
                _health--;
                _playerAnimation.SetFade();
                OnHealthChange?.Invoke(_health);

                if (_health <= 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            coin.PickUp();
            _coinScore++;
            OnCoinScoreChange?.Invoke(_coinScore);
        }
    }
}
