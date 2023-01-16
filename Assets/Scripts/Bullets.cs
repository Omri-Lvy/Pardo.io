using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using Scripts;
using UnityEngine;
using Timer = System.Timers.Timer;

public class Bullets : MonoBehaviour
{
    private Vector3 mousePosition;
    private Camera mainCamera;
    private Rigidbody rb;
    public float force;
    public float damage;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody>();
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getStats().getAttack();
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        Destroy(this.gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            health--;
            if(!other.gameObject.GetComponent<Enemy>().getStats().isDead()) {
                other.gameObject.GetComponent<Enemy>().getHit(damage);
                if(health == 1) {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
