using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _walkingSpeed = 5f;
    public Animator animator;

    public Quaternion q;
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
        if (horizontalInput != 0 || verticalInput != 0) {
            animator.SetBool("walk",true);
        }
        else {
            animator.SetBool("walk",false);
        }
        if (horizontalInput < 0) {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
            horizontalInput = -horizontalInput;
        }
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * (_walkingSpeed * Time.deltaTime));
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,-4.5f,4.5f), 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-8.4f,8.4f),transform.position.y,0);
    }
}