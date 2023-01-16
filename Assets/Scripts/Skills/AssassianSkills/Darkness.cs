using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    [SerializeField] public Animator _animator;
    public float expRadius;
    public int damage;
    public float consistTime;

    private void Start() {
        InvokeRepeating("darknessDamage", 0f, 0.7f);
        Invoke("clearout", consistTime + 0.04f);
    }

    private void clearout() {
        Destroy(gameObject, 0.4f);
        _animator.Play("Darkness_Domain_clearout");
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
