using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Levels : MonoBehaviour
{
    [SerializeField] private UIDocument _levelsUIDocument;
    [SerializeField] private Player _player;
    
    private VisualElement _rootVisualElement;
    private Label _healthLabel;
    private Label _coinsLabel;

    private void Awake()
    {
        _rootVisualElement = _levelsUIDocument.rootVisualElement;

        _healthLabel = _rootVisualElement.Q<Label>("HealthLabel");
        _coinsLabel = _rootVisualElement.Q<Label>("CoinsLabel");
    }

    private void OnEnable()
    {
        _player.OnHealthChange += OnHealthChange;
        _player.OnCoinScoreChange += OnCoinScoreChange;
    }

    private void OnDisable()
    {
        _player.OnHealthChange -= OnHealthChange;
        _player.OnCoinScoreChange -= OnCoinScoreChange;
    }

    private void OnHealthChange(int arg0)
    {
        _healthLabel.text = $"Health: {arg0}";
    }

    private void OnCoinScoreChange(int arg0)
    {
        _coinsLabel.text = $"Coins: {arg0}";
    }
}
