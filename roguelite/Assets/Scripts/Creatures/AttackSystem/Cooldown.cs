using System.Collections;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    public float CooldownTime { get; set; }
    public bool IsReady { get; private set; }

    private void Awake()
    {
        IsReady = true;
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
    }
}
