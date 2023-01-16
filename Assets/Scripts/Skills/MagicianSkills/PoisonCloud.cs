using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCloud : MonoBehaviour
{
    private Vector3 mousePosition;
    private Camera mainCamera;
    private Rigidbody rb;
    [SerializeField] public Animator _animator;
    private bool didHit = false;
    public float expRadius;
    public int damage;
    public float consistTime;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Fart");
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
                if (!didHit)
                {
                    _animator.Play("Poison_Cloud_hit");
                    Destroy(gameObject, consistTime);
                    Invoke("playLingerAnim", 0.1f);
                    Invoke("playClearoutAnim", consistTime - 1f);
                    InvokeRepeating("poisonLinger", 0f, 1f);
                    didHit = true;
                }
            }
        }
    }

    private void playLingerAnim()
    {
        FindObjectOfType<AudioManager>().Play("PoisonCloudConsist");
        _animator.Play("Poison_Cloud_consist");
    }

    private void playClearoutAnim()
    {
        _animator.Play("Poison_Cloud_clearout");
    }

    private void poisonLinger()
    {
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
