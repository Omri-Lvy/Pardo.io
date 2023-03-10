using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepillar : MonoBehaviour
{
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(1, 3);
        if (rand == 1)
        {
            FindObjectOfType<AudioManager>().Play("Firepillar1");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Firepillar2");
        }
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (!other.gameObject.GetComponent<Enemy>().getStats().isDead())
            {
                other.gameObject.GetComponent<Enemy>().getHit(damage);
            }
        }
    }
}
