using System.Collections;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    [SerializeField] protected float _initialCooldown;

    public float CooldownTime { get; set; }
    public float InitialCooldown => _initialCooldown;
    public bool IsReady { get; private set; }

    private void Awake()
    {
        IsReady = true;
        ResetCooldownTime();
    }

    public bool TryRestartCooldown()
    {
        if (!IsReady)
            return false;

        IsReady = false;
        StartCoroutine(WaitCooldownTime());
        
        return true;
    }

    public void ResetCooldownTime()
    {
        CooldownTime = _initialCooldown;
    }

    private IEnumerator WaitCooldownTime()
    {
        yield return new WaitForSeconds(CooldownTime);
        IsReady = true;
    }
}
