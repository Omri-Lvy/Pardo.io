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
        
        // wrap player movment
        if (transform.position.y >= 6.6f)
        {
            transform.position = new Vector3(transform.position.x, -6.6f, 0);
        }
        else if (transform.position.y <= -6.6f)
        {
            transform.position = new Vector3(transform.position.x, 6.6f, 0);   
        }
        if (transform.position.x >= 14.3)
        {
            transform.position = new Vector3(-14.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -14.3f)
        {
            transform.position = new Vector3(14.3f, transform.position.y, 0);   
        }
        
        /*
         * limit user movement
         *  transform.position = new Vector3(transform.position.x, Mathf.clamp(transform.position.y,-6,6), 0); 
         *  transform.position = new Vector3(Mathf.clamp(transform.position.x,-13.5,13.5),transform.position.y , 0); 
         */
    }
}
