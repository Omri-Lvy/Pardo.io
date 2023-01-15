using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cooldown : Component
{
    private bool _isCooldown;
    private float _cooldownTime;
    private float _cooldownTimer;
    private GameObject button;
    private Image background;

    public Cooldown(float cooldownTime, char buttonNum) {
        _isCooldown = false;
        _cooldownTime = cooldownTime;
        _cooldownTimer = cooldownTime;
        button = GameObject.Find("Button" + buttonNum);
        background = button.transform.GetChild(0).gameObject.GetComponent<Image>();
        background.fillAmount = 0.0f;
    }

    // Handle Cooldown timer, to be called in Update()
    public void HandleCooldown() {
        if(_isCooldown) {
            _cooldownTimer -= Time.deltaTime;
            if(_cooldownTimer < 0.0f) {
                _isCooldown = false;
                _cooldownTimer = _cooldownTime;
                background.fillAmount = 0.0f;
            } else {
                background.fillAmount = _cooldownTimer / _cooldownTime;
            }
        }
    }

    // Setter for Cooldown
    public void SetCooldown(bool val) {
        _isCooldown = val;
    }
    
    // Getter for Cooldown
    public float getCooldown() {
        return _cooldownTimer;
    }

    // Returns if the skill is ready to use
    public bool skillReady() {
        return !_isCooldown;
    }
}
