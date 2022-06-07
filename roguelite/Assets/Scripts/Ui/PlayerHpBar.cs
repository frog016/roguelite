using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    private DamageableObject _player;
    [SerializeField] private Image _bar;

    private void Start()
    {
        LevelGenerationManager.Instance.OnGenerationEndedEvent.AddListener(() =>
        {
            _player = PlayerSpawner.Instance?.Player;
            ChangeHpValue();
            _player?.OnHealthChanged?.AddListener(ChangeHpValue);
        });
    }

    private void ChangeHpValue()
    {
        _bar.fillAmount = _player.Health / _player.MaxHealth;
    }
}
