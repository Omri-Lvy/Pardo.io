using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCollision : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    private CanvasGroup _canvasgroup;
    private GameObject _player;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _canvasgroup = _canvas.GetComponent<CanvasGroup>();
    }
    
    private void Update() {
        _canvasgroup = _canvas.GetComponent<CanvasGroup>();
        float playerX = _player.transform.position.x;
        float playerY = _player.transform.position.y;
        if(_canvasgroup != null) {
            if(playerX < -3.8 && playerY < -2.7) {
                _canvasgroup.alpha = 0.4f;
            } else {
                _canvasgroup.alpha = 1f;
            }
        }
    }
}
