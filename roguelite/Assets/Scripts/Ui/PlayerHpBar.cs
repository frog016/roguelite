using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    private HeroSamurai Player;
    [SerializeField] private Image BarFront;
    [SerializeField] private TMP_Text HpText;

    void Update()
    {
        if (Player == null)
        {
            var obj = GameObject.Find("/Player(Clone)");
            Player = obj == null ? null : obj.GetComponent<HeroSamurai>();
        }
        else
        {
            BarFront.fillAmount = Player.Health / Player.MaxHealth;
            HpText.text = Player.Health.ToString();
        }
    }
}
