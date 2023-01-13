using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : Component
{
    private bool _isCooldown;
    private float _cooldownTime;
    private float _cooldownTimer;

    public Cooldown(float cooldownTime) {
        _isCooldown = false;
        _cooldownTime = cooldownTime;
        _cooldownTimer = cooldownTime;
    }

    // Handle Cooldown timer, to be called in Update()
    public void HandleCooldown() {
        if(_isCooldown) {
            _cooldownTimer -= Time.deltaTime;
            if(_cooldownTimer < 0.0f) {
                _isCooldown = false;
                _cooldownTimer = _cooldownTime;
            }
        }
    }

    // Setter for Cooldown
    public void SetCooldown(bool val) {
        _isCooldown = val;
    }

    // Returns if the skill is ready to use
    public bool skillReady() {
        return !_isCooldown;
    }
}
