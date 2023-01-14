using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSkills : MonoBehaviour
{
    private bool _waveShot, _arrowRain, _homing;
    [SerializeField] private GameObject arrowRain;
    [SerializeField] private GameObject waveShot;
    [SerializeField] private GameObject homing;
    public float arrowRainCDtime;        // These variables set the "max" cooldown time.
    public float waveShotCDtime;
    public float homingCDtime;
    private Transform _transform;
    private Cooldown arrowRainCD;        
    private Cooldown waveShotCD;
    private Cooldown homingCD;

    private Camera mainCamera;
    private Vector3 mousePos;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _transform = transform.Find("Aim");
        _waveShot = true;
        _arrowRain = true;
        _homing = true;
        arrowRainCD = new Cooldown(arrowRainCDtime);
        waveShotCD = new Cooldown(waveShotCDtime);
        homingCD = new Cooldown(homingCDtime);
    }

    // Update is called once per frame
    void Update()
    {
        // Handle CDs
        arrowRainCD.HandleCooldown();
        waveShotCD.HandleCooldown();
        homingCD.HandleCooldown();

        // Handle input
        if(Input.GetKeyDown("1") && _waveShot && waveShotCD.skillReady()) {
            waveShotCD.SetCooldown(true);
            WaveShot();
        }
        if(Input.GetKeyDown("3") && _arrowRain && arrowRainCD.skillReady()) {
            arrowRainCD.SetCooldown(true);
            ArrowRain();
        }
        if(Input.GetKeyDown("2") && _homing && homingCD.skillReady()) {
            homingCD.SetCooldown(true);
            Homing();
        }
    }

    private void ArrowRain() {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z += 10;
        mousePos.y += arrowRain.GetComponent<CapsuleCollider>().height / 2.1f; // This offsets the start position
        Instantiate(arrowRain, mousePos, Quaternion.identity);
    }

    private void WaveShot() {
        Instantiate(waveShot, _transform.position, _transform.rotation);
    }

    private void Homing() {
        Instantiate(homing, _transform.position, _transform.rotation);
    }
    
}
