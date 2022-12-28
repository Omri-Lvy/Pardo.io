using UnityEngine;
using UnityEngine.UIElements;


public class PlayerAimWeapon : MonoBehaviour
{

    private Camera mainCamera;
    private Vector3 mousePos;
    private bool canFire = true;
    private float timer;
    private int maxShots = 10;
    private int shotFired = 0;
    private float timeBetweenShots = 0.5f;

    public GameObject bullet;
    public Transform aimTransform;

    // Start is called before the first frame update
    private void Start()
    {
        aimTransform = transform.Find("Aim");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleAiming();
        HandleShooting();
    }

    private void HandleAiming()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.rotation = Quaternion.Euler(0,0,angle);
    }

    private void HandleShooting()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenShots)
            {
                canFire = true;
                timer = 0;
                shotFired = 0;
            }
        }
        if (canFire)
        {
            canFire = false;
            Instantiate(bullet, aimTransform.position, Quaternion.identity);
            shotFired += 1;
        }
        
    }
    
}

