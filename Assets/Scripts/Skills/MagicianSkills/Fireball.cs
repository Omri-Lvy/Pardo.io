using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Vector3 mousePosition;
    private Camera mainCamera;
    private Rigidbody rb;
    [SerializeField] public Animator _animator;
    public float expRadius;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("FireballMove");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody>();
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * 5;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            FindObjectOfType<AudioManager>().Stop("FireballMove");
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (!other.gameObject.GetComponent<Enemy>().getStats().isDead())
            {
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                _animator.Play("Fire_Ball_hit");
                FindObjectOfType<AudioManager>().Play("FireballHit");
                FindObjectOfType<AudioManager>().Stop("FireballMove");
                Destroy(gameObject, 1f);
                Collider[] enemies = Physics.OverlapSphere(gameObject.transform.position, expRadius);
                foreach (Collider collider in enemies)
                {
                    if (collider != null && collider.tag == "Enemy")
                    {
                        collider.gameObject.GetComponent<Enemy>().getHit(damage);
                    }
                }
            }
        }
    }
}
