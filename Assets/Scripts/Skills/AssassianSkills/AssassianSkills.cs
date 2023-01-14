using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssassianSkills : MonoBehaviour
{
    private bool _darkness, _x, _shuriken;
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
        _shuriken = true;
        _darkness = true;
        _x = true;
        darknessCD = new Cooldown(darknessCDtime);
        shurikenCD = new Cooldown(shurikenCDtime);
        xCD = new Cooldown(xCDtime);
    }

    // Update is called once per frame
    void Update()
    {
        // Handle CDs
        darknessCD.HandleCooldown();
        shurikenCD.HandleCooldown();
        xCD.HandleCooldown();

        // Handle input
        if(Input.GetKeyDown("1") && _shuriken && shurikenCD.skillReady()) {
            shurikenCD.SetCooldown(true);
            Shuriken();
        }
        if(Input.GetKeyDown("3") && _darkness && darknessCD.skillReady()) {
            darknessCD.SetCooldown(true);
            Darkness();
        }
        if(Input.GetKeyDown("2") && _x && xCD.skillReady()) {
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
