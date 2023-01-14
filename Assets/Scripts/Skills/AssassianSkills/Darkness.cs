using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    [SerializeField] public Animator _animator;
    public float expRadius;
    public int damage;
    public float consistTime;
    private bool didHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if(!other.gameObject.GetComponent<Enemy>().getStats().isDead()) {
                if(!didHit) {
                    Destroy(gameObject, consistTime);
                    InvokeRepeating("darknessDamage", 0f, 0.5f);
                    didHit = true;
                }
            }
        }
    }

    private void darknessDamage() {
        Collider[] enemies = Physics.OverlapSphere(gameObject.transform.position, expRadius);
        foreach (Collider collider in enemies)
        {
            if(collider != null && collider.tag == "Enemy") {
                collider.gameObject.GetComponent<Enemy>().getHit(damage);
            }
        }
}
}
