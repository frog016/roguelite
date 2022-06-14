using System;
using UnityEngine;

[Serializable]
public class MovementData
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashActiveTime;
    [SerializeField] private float _dashCooldown;

    public float MoveSpeed => _moveSpeed;
    public float DashSpeed => _dashSpeed;
    public float DashActiveTime => _dashActiveTime;
    public float DashCooldown => _dashCooldown;
}
