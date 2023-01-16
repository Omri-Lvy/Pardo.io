using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X : MonoBehaviour
{
    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if(!other.gameObject.GetComponent<Enemy>().getStats().isDead()) {
                other.gameObject.GetComponent<Enemy>().getHit(damage);
            }
        }
    }
}
