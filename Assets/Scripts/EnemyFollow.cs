using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player = GameObject.FindWithTag("Pardo");
    public float speed = 2;

    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        if (player.transform.position.x > transform.position.x) {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        if (player.transform.position.x < transform.position.x) {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
