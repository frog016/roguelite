using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Cooldown : MonoBehaviour
{
    public float CooldownTime { get; set; }
    public bool IsReady { get; private set; }
    public UnityEvent OnCooldownRestarted { get; private set; }

    private void Awake()
    {
        IsReady = true;
        OnCooldownRestarted = new UnityEvent();
    }

    public bool TryRestartCooldown()
    {
        if (!IsReady)
            return false;

        IsReady = false;
        StartCoroutine(WaitCooldownTime());
        
        return true;
    }

    private IEnumerator WaitCooldownTime()
    {
        yield return new WaitForSeconds(CooldownTime);
        IsReady = true;
        OnCooldownRestarted.Invoke();
    }
}
