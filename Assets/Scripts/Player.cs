using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _walkingSpeed = 2.25f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Reset position to (0,0,0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        
        transform.Translate(direction * (_walkingSpeed * Time.deltaTime));
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,-5f,5f), 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-9.25f,9.25f),transform.position.y,0);
    }
}
