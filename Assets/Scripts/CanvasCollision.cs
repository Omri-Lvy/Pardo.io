using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCollision : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag+", "+other.name);
        if (other.tag == "Player" || other.name == "Pardo")
        {
            _canvas.GetComponent<CanvasGroup>().alpha = 0.2f;
        }
            
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            _canvas.GetComponent<CanvasGroup>().alpha = 1f;
        }
            
    }
}
