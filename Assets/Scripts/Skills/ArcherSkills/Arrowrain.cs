using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowrain : MonoBehaviour
{
    [SerializeField] public Animator _animator;
    public float expRadius;
    public int damage;
    public float consistTime;
    private Vector3 originalPos;

    private void Start() {
        originalPos = gameObject.transform.position;
        gameObject.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0f, 1f, 0f);
        Invoke("playRainAnim", 0.7f);
        InvokeRepeating("rainDamage", 0.7f, 1f);
        Destroy(gameObject, consistTime + 0.7f);    
    }
    private void playRainAnim() {
        gameObject.transform.position = originalPos;
        _animator.Play("Arrow_Rain_consisting");
    }

    private void rainDamage() {
        Collider[] enemies = Physics.OverlapSphere(gameObject.transform.position, expRadius);
        foreach (Collider collider in enemies)
        {
            if(collider != null && collider.tag == "Enemy") {
                collider.gameObject.GetComponent<Enemy>().getHit(damage);
            }
        }
}
}
