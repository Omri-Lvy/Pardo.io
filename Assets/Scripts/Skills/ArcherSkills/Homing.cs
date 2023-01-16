using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    private Vector3 mousePosition;
    private Camera mainCamera;
    private Rigidbody rb;
    private GameObject target;
    private GameObject [] targets;
    [SerializeField] public Animator _animator;
    public int damage;
    public int amountOfHits;
    public float speed;
    public float turningSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        newTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null || target.GetComponent<Enemy>().getStats().isDead()) {
            newTarget();
        }
        if(amountOfHits != 0) {
            Vector3 Target = target.transform.position;
            Vector3 distance = Target - transform.position;
            var angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,angle), turningSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            if(!other.gameObject.GetComponent<Enemy>().getStats().isDead()) {
                other.gameObject.GetComponent<Enemy>().getHit(damage);
                amountOfHits--;
                if(amountOfHits == 0) {
                    destroyArrow();
                }
                newTarget();
            }
        }
    }

    private void destroyArrow() {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        _animator.Play("Homming_Arrow_hit");
        Destroy(gameObject,0.4f);
    }

    public void newTarget() {
        targets = GameObject.FindGameObjectsWithTag("Enemy");
        if(targets.Length == 0) {
            destroyArrow();
        }
        var randomIndex = Random.Range(0, targets.Length);
        target = targets[randomIndex];
    }
}
