using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Scripts;

public class CanvasCollision : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    private CanvasGroup _canvasgroup;
    private GameObject _player;
    private GameObject _prevPlayer;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;

    [SerializeField] private Sprite MageSkill1;
    [SerializeField] private Sprite MageSkill2;
    [SerializeField] private Sprite MageSkill3;

    [SerializeField] private Sprite ArcherSkill1;
    [SerializeField] private Sprite ArcherSkill2;
    [SerializeField] private Sprite ArcherSkill3;

    [SerializeField] private Sprite AssassinSkill1;
    [SerializeField] private Sprite AssassinSkill2;
    [SerializeField] private Sprite AssassinSkill3;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _prevPlayer = _player;
        _canvasgroup = _canvas.GetComponent<CanvasGroup>();
        HandleCooldownButtons(); // Change the buttons to the according class
    }

    private void HandleCooldownButtons() {
        PlayerStats stats = _player.GetComponent<Player>().getStats();
        if(_player.name == "Pardo") {
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
        } else {
            bool [] skills = stats.getSkills();
            button1.SetActive(skills[0]);
            button2.SetActive(skills[1]);
            button3.SetActive(skills[2]);
        }
        if(_player.name == "PardoMagician(Clone)") {
            button1.GetComponent<Image>().sprite = MageSkill1;
            button2.GetComponent<Image>().sprite = MageSkill2;
            button3.GetComponent<Image>().sprite = MageSkill3;
        }
        if(_player.name == "PardoArcher(Clone)") {
            button1.GetComponent<Image>().sprite = ArcherSkill1;
            button2.GetComponent<Image>().sprite = ArcherSkill2;
            button3.GetComponent<Image>().sprite = ArcherSkill3;
        }
        if(_player.name == "PardoAssassin(Clone)") {
            button1.GetComponent<Image>().sprite = AssassinSkill1;
            button2.GetComponent<Image>().sprite = AssassinSkill2;
            button3.GetComponent<Image>().sprite = AssassinSkill3;
        }
    }
    
    private void Update() {
        _player = GameObject.FindGameObjectWithTag("Player");
        
        HandleCooldownButtons();
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