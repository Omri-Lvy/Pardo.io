using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianSkills : MonoBehaviour
{
    private bool [] _skills;
    [SerializeField] private GameObject fireball;
    [SerializeField] private GameObject firepillar;
    [SerializeField] private GameObject poisonCloud;
    public float fireballCDtime;        // These variables set the "max" cooldown time.
    public float firepillarCDtime;
    public float poisonCloudCDtime;
    private Transform _transform;
    private Cooldown fireballCD;        
    private Cooldown firepillarCD;
    private Cooldown poisonCloudCD;

    private Camera mainCamera;
    private Vector3 mousePos;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _transform = transform.Find("Aim");
        _skills = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getStats().getSkills();
        fireballCD = new Cooldown(fireballCDtime, '1');
        firepillarCD = new Cooldown(firepillarCDtime, '2');
        poisonCloudCD = new Cooldown(poisonCloudCDtime, '3');
    }

    // Update is called once per frame
    void Update()
    {
        _skills = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getStats().getSkills();
        // Handle CDs
        fireballCD.HandleCooldown();
        firepillarCD.HandleCooldown();
        poisonCloudCD.HandleCooldown();

        // Handle input
        if(Input.GetKeyDown("1") && _skills[0] && fireballCD.skillReady()) {
            fireballCD.SetCooldown(true);
            Fireball();
        }
        if(Input.GetKeyDown("2") && _skills[1] && firepillarCD.skillReady()) {
            firepillarCD.SetCooldown(true);
            Firepillar();
        }
        if(Input.GetKeyDown("3") && _skills[2] && poisonCloudCD.skillReady()) {
            poisonCloudCD.SetCooldown(true);
            PoisonCloud();
        }
    }

    private void Fireball() {
        Instantiate(fireball, _transform.position, _transform.rotation);
    }

    private void Firepillar() {
        
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z += 10;
        mousePos.y += firepillar.GetComponent<CapsuleCollider>().height / 2.1f;
        Instantiate(firepillar, mousePos, Quaternion.identity);
    }

    private void PoisonCloud() {
        Instantiate(poisonCloud, _transform.position, _transform.rotation);
    }
    
}
