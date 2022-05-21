using System.Collections;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    public float CooldownTime { get; set; }
    public float InitialCooldown { get; protected set; }
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

    public void ResetCooldownTime(float time = 0f)
    {
        if (time != 0f)
            InitialCooldown = time;
        CooldownTime = InitialCooldown;
    }

    private IEnumerator WaitCooldownTime()
    {
        yield return new WaitForSeconds(CooldownTime);
        IsReady = true;
    }
}
