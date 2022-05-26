using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    private DamageableObject _player;
    [SerializeField] private Image _bar;

    private void Update()
    {
        if (_player != null)
            return;

        _player = PlayerSpawner.Instance?.Player;
        ChangeHpValue();
        _player?.OnHealthChanged?.AddListener(ChangeHpValue);
    }

    private void ChangeHpValue()
    {
        if (_player == null)
            return;

        _bar.fillAmount = _player.Health / _player.MaxHealth;
    }
}
