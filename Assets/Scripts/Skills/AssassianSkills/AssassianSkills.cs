using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssassianSkills : MonoBehaviour
{
    private bool [] _skills;
    [SerializeField] private GameObject darkness;
    [SerializeField] private GameObject shuriken;
    [SerializeField] private GameObject x;
    public float darknessCDtime;        // These variables set the "max" cooldown time.
    public float shurikenCDtime;
    public float xCDtime;
    private Transform _transform;
    private Cooldown darknessCD;        
    private Cooldown shurikenCD;
    private Cooldown xCD;

    private Camera mainCamera;
    private Vector3 mousePos;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _transform = transform.Find("Aim");
        _skills = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getStats().getSkills();
        darknessCD = new Cooldown(darknessCDtime, '3');
        shurikenCD = new Cooldown(shurikenCDtime, '1');
        xCD = new Cooldown(xCDtime, '2');
    }

    // Update is called once per frame
    void Update()
    {
        _skills = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getStats().getSkills();
        // Handle CDs
        darknessCD.HandleCooldown();
        shurikenCD.HandleCooldown();
        xCD.HandleCooldown();

        // Handle input
        if(Input.GetKeyDown("1") && _skills[0] && shurikenCD.skillReady()) {
            shurikenCD.SetCooldown(true);
            Shuriken();
        }
        if(Input.GetKeyDown("3") && _skills[2] && darknessCD.skillReady()) {
            darknessCD.SetCooldown(true);
            Darkness();
        }
        if(Input.GetKeyDown("2") && _skills[1] && xCD.skillReady()) {
            xCD.SetCooldown(true);
            X();
        }
    }

    private void Darkness() {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z += 10;
        mousePos.y += darkness.GetComponent<CapsuleCollider>().height / 3f;
        Instantiate(darkness, mousePos, Quaternion.identity);
    }

    private void Shuriken() {
        
        Instantiate(shuriken, _transform.position, _transform.rotation);
    }

    private void X() {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z += 10;
        //mousePos.y += firepillar.GetComponent<CapsuleCollider>().height / 2.1f; // This offsets the start position
        Instantiate(x, mousePos, Quaternion.identity);
    }
    
}
